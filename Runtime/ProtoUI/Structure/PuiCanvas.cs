using HexUN.MonoB;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HexUN.UXUI
{
    /// <summary>
    /// Pui handler for canvas relative operations. Exists because graphic raycasting occurs per
    /// canvas even for nested canvases, so there needs to be a hierarchical solution
    /// </summary>
    public class PuiCanvas : MonoEnhanced
    {
        [SerializeField]
        private Canvas _canvas;

        [SerializeField]
        private GraphicRaycaster _raycaster;

        [SerializeField]
        private List<PuiCanvas> _children;

        #region API
        /// <summary>
        /// The canvas managed byt the PuiCanvas script
        /// </summary>
        public Canvas Canvas => _canvas;

        /// <summary>
        /// The raycaster used to do raycasts at the canvas level
        /// </summary>
        public GraphicRaycaster Raycaster => _raycaster;

        /// <summary>
        /// perform a raycast on all canvases and return all results
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<RaycastResult> PerformRaycast(PointerEventData data)
        {
            List<RaycastResult> results = new List<RaycastResult>();
            Raycaster.Raycast(data, results);

            foreach(PuiCanvas can in _children)
            {
                results.AddRange(can.PerformRaycast(data));
            }

            return results;
        }
        #endregion

        private void OnValidate()
        {
            _canvas = gameObject.GetComponent<Canvas>();
            _raycaster = gameObject.GetComponent<GraphicRaycaster>();

            _children = FindChildren();
        }


        private List<PuiCanvas> FindChildren()
        {
            List<PuiCanvas> children = new List<PuiCanvas>();
            Queue<Transform> process = new Queue<Transform>();

            // get the children to process
            foreach (Transform child in transform)
            {
                if (child == transform) continue;
                process.Enqueue(child);
            }

            while(process.Count > 0)
            {
                Transform t = process.Dequeue();
                PuiCanvas pui = t.gameObject.GetComponent<PuiCanvas>();

                if(pui == null)
                {
                    Canvas c = t.gameObject.GetComponent<Canvas>();
                    if (c != null) pui = t.gameObject.AddComponent<PuiCanvas>();
                }

                if(pui != null)
                {
                    children.Add(pui);
                } else
                {
                    foreach (Transform child in t)
                    {
                        if (child == t) continue;
                        process.Enqueue(child);
                    }
                }
            }

            return children;
        }
    }
}