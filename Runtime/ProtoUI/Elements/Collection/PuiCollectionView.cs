using System.Collections.Generic;
using UnityEngine;

namespace HexUN.UXUI
{
    /// <summary>
    /// A Ui Collection is a List like strucutre of Ui elements. It's purpose is to
    /// easily manage the elements in a group of common ui elements (like a grid
    /// or list) independent of the functionality of those elements. 
    /// </summary>
    public class PuiCollectionView : APuiView<PuiCollectionControl>
    {
        [SerializeField]
        [Tooltip("The gameobject to use as the parent of instantiated gameobjects")]
        private Transform _parent;

        [SerializeField]
        private int _maxCanRender = 10;

        protected override void HandleFrameRender()
        {
            GameObject[] currentElements = Control.CurrentElements;

            for (int i = 0; i< currentElements.Length; i++)
            {
                if (i >= _maxCanRender) break;

                GameObject el = currentElements[i];
                el.transform.SetParent(_parent, false);
                el.SetActive(true);
            }
        }
    }
}