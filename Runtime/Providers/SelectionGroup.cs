using UnityEngine;

namespace HexUN.UXUI
{
    [CreateAssetMenu(fileName = "selectionGroup", menuName = "HexUN/UXUI/SelectionGroup")]
    public class SelectionGroup : ScriptableObject
    {

        /// <summary>
        /// The seleted seletion provider. The GameObject this provider is attached to
        /// is the selected gameobject.
        /// </summary>
        public SelectionProvider Selected { get; set; } = null;
    }
}