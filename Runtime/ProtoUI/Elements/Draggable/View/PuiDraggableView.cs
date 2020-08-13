using UnityEngine;
using UnityEngine.UI;

namespace HexUN.UXUI
{
    public class PuiDraggableView : APuiDraggableView
    {
        [Header("Options")]
        [Tooltip("Canvas dragging should be relative to")]
        public Canvas DragCanvas = null;

        [Tooltip("Spawned dragg boject should be size of")]
        public RectTransform MatchTransform = null;

        public SpriteArgs Icon = null;

        [SerializeField]
        private Image _image = null;

        private GameObject _dragObject = null;

        public override void Initialize()
        {
            Icon.ApplyToImage(_image);
        }

        protected override void HandleFrameRender()
        {
        }
        
        public void HandleDragBegin(Vector2 data)
        {
            _dragObject = new GameObject("DraggingIcon", typeof(RectTransform));
            RectTransform rt = _dragObject.transform as RectTransform;
            rt.transform.SetParent(DragCanvas.transform, false);
            rt.transform.SetAsLastSibling();
            rt.sizeDelta = new Vector2(MatchTransform.rect.width, MatchTransform.rect.height);

            Image img = _dragObject.AddComponent<Image>();
            Icon.ApplyToImage(img);
            _image.enabled = false;

            SetDragObjectPosition(data);
        }

        public void HandleDrag(Vector2 data)
        {
            SetDragObjectPosition(data);
        }

        public void HandleDrop(Vector2 data)
        {
            OnDroppedEvent.Invoke(data);
            _image.enabled = true;
            Destroy(_dragObject);
        }

        private void SetDragObjectPosition(Vector2 pos)
        {
            if (_dragObject == null) return;
            ((RectTransform)_dragObject.transform).position = pos;
        }
    }
}
