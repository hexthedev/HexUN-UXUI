using HexUN.MonoB;
using UnityEngine;
using HexUN.Animation;
using HexUN.Math;

namespace HexUN.UXUI
{
    /// <summary>
    /// Slides a rect transform back and forth using an interpolation
    /// </summary>
    public class SlideRectTransform : MonoEnhanced
    {
        [Header("Options")]
        [SerializeField]
        [Tooltip("The target transform to slide")]
        private RectTransform _target = default;

        [SerializeField]
        [Tooltip("How far should the element move")]
        private float _distance = default;

        [SerializeField]
        [Tooltip("Does it hide by going left, or going right")]
        private bool _isLeft = default;

        [SerializeField]
        [Tooltip("Time in seconds")]
        private float _speed = default;

        [SerializeField]
        [Tooltip("The Easing function to use")]
        private EEasingFunction _ease = default;

        private int _interpolationId = 0;
        private float _startAnchorX = 0;

        /// <summary>
        /// Slide the rect transform to hidden or to visable slide positions
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public void Slide(bool state)
        {
            IInterpolationToken<float[]> token = InterpolationManager.Instance.StartInterpolation(
                _interpolationId,
                _speed,
                new SInterpolation(
                    state ? _startAnchorX : _isLeft ? _startAnchorX - _distance : _startAnchorX + _distance,
                    state ? _isLeft ? _startAnchorX - _distance : _startAnchorX + _distance : _startAnchorX,
                    _ease
                ) );

            EventBindings.Add(token.OnInterpolationCanceledSubscriber.Subscribe(HandleEndOrCancel));
            EventBindings.Add(token.OnInterpolationEndSubscriber.Subscribe(HandleEndOrCancel));
            EventBindings.Add(token.OnInterpolationSubscriber.Subscribe(HandleInterpolation));
        }

        protected override void MonoStart()
        {
            _interpolationId = InterpolationManager.Instance.GetUniqueId();
            _startAnchorX = _target.anchoredPosition.x;
        }

        private void HandleEndOrCancel()
        {
            EventBindings.ClearAndUnsubscribeAll();
        }

        private void HandleInterpolation(float[] value)
        {
            _target.anchoredPosition = new Vector2(value[0], _target.anchoredPosition.y);
        }
    }
}