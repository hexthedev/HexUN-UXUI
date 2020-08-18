using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HexUN.UXUI
{
    public class PuiDraggableView : APuiDraggableView
    {
        [Header("Options")]
        [Tooltip("Canvas dragging should be relative to")]
        public Canvas DragCanvas = null;

        public SpriteArgs Icon = null;

        [SerializeField]
        private Image _image = null;

        private GameObject _dragObject = null;

        public override void Initialize()
        {
            Icon?.ApplyToImage(_image);
        }

        protected override void HandleFrameRender()
        {
        }
        
        public void HandleDragBegin(PointerEventData data)
        {
            _dragObject = new GameObject("DraggingIcon", typeof(RectTransform));
            RectTransform rt = _dragObject.transform as RectTransform;
            rt.transform.SetParent(DragCanvas.transform, false);
            rt.transform.SetAsLastSibling();

            RectTransform copying = transform as RectTransform;
            if(copying != null) rt.sizeDelta = new Vector2(copying.rect.height, copying.rect.width);

            Image img = _dragObject.AddComponent<Image>();
            Icon?.ApplyToImage(img);
            _image.enabled = false;

            SetDragObjectPosition(data);
        }

        public void HandleDrag(PointerEventData data)
        {
            SetDragObjectPosition(data);
        }

        public void HandleDrop(PointerEventData data)
        {
            OnDroppedEvent.Invoke(data);
            _image.enabled = true;
            Destroy(_dragObject);
        }

        private void SetDragObjectPosition(PointerEventData data)
        {
            if (_dragObject == null) return;
            ((RectTransform)_dragObject.transform).position = data.position;
        }
    }
}
