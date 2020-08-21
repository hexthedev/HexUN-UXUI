using System.Collections.Generic;
using UnityEngine;

namespace HexUN.UXUI
{
    /// <summary>
    /// A PuiChildren is a List like strucutre of Ui elements that are children of it's transform. 
    /// It's purpose is to easily manage the elements in a group of common ui elements (like a grid
    /// or list) independent of the functionality of those elements. 
    /// </summary>
    public abstract class APuiChildrenCollectionControl : APuiControl
    {
        private List<GameObject> _currentElements = new List<GameObject>();

        #region API
        /// <summary>
        /// CurretnElements added to the control
        /// </summary>
        public GameObject[] CurrentElements => _currentElements.ToArray();
        
        /// <summary>
        /// Add a GameObject as a child of this object
        /// </summary>
        /// <param name="element"></param>
        public void AddElement(GameObject element)
        {
            _currentElements.Add(element);
            element.SetActive(false);
            Render();
        }

        /// <summary>
        /// Destroy and remove an element from the collection
        /// </summary>
        /// <param name="element"></param>
        public void RemoveElement(GameObject element)
        {
            GameObject el = _currentElements.Find(e => e == element);

            if (el != null)
            {
                Destroy(el);
                _currentElements.Remove(el);
                Render();
            }
        }

        /// <summary>
        /// Destroy all children of this object and clear tracking
        /// </summary>
        public void Clear()
        {
            foreach(GameObject go in _currentElements)
            {
                Destroy(go);
            }

            _currentElements.Clear();

            foreach (Transform child in transform) Destroy(child.gameObject); // Destroy remaining children

            Render();
        }
        #endregion
    }
}