using System;
using UnityEngine;
using UnityEngine.UI;

namespace HexUN.UXUI
{
    public class PuiDraggableView : APuiDraggableView
    {
        [Header("Options")]
        [SerializeField]
        [Tooltip("Canvas dragging should be relative to")]
        private Canvas _dragCanvas = null;

        [SerializeField]
        [Tooltip("Spawned dragg boject should be size of")]
        private RectTransform _matchTransform = null;

        [SerializeField]
        private SpriteArgs _icon = null;

        [SerializeField]
        private Image _image = null;

        private GameObject _dragObject = null;

        public override void Initialize() => throw new NotImplementedException();
        protected override void HandleFrameRender() => throw new NotImplementedException();


        public void HandleDragBegin(Vector2 data)
        {
            _dragObject = new GameObject("DraggingIcon", typeof(RectTransform));
            RectTransform rt = _dragObject.transform as RectTransform;
            rt.transform.SetParent(_dragCanvas.transform, false);
            rt.transform.SetAsLastSibling();
            rt.sizeDelta = new Vector2(_matchTransform.rect.width, _matchTransform.rect.height);

            Image img = _dragObject.AddComponent<Image>();
            _icon.ApplyToImage(img);
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
