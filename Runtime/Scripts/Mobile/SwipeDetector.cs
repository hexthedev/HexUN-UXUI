using HexUN;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HexUN.UXUI
{
    /// <summary>
    /// Can be put on a UI element that received UI input raycasts (Graphics Raycast Handler). 
    /// Basically this class detct a drag and if the beginning and end drag distance is over a certain magnitude
    /// the swipe is considered successful in a particular direction
    /// </summary>
    public class SwipeDetector : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private const float cNormalizedDot45Degress = 0.7071068f;

        [SerializeField]
        [Tooltip("Event over which swipe data will be propagated")]
        private SSwipeDataEvent _swipeEvent = null;

        [SerializeField]
        [Tooltip("The distance in pixels required for a drag completion to occur")]
        private float _threshold = 100;

        private Vector2 _dragStartPosition = Vector2.zero;
        private ESwipeDirection _currentDetectedDirection = ESwipeDirection.RIGHT;

        #region API
        public void OnBeginDrag(PointerEventData eventData)
        {
            // record the start position
            _dragStartPosition = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            // detect the direction
            Vector2 normalizedDirection = (eventData.position - _dragStartPosition).normalized;
            
            if(!DetectDotDirectionSingleAxis(normalizedDirection, Vector2.right, ESwipeDirection.RIGHT, ESwipeDirection.LEFT))
            {
                DetectDotDirectionSingleAxis(normalizedDirection, Vector2.up, ESwipeDirection.UP, ESwipeDirection.DOWN);
            }

            // invoke the event and pass info to relevent listeners
            _swipeEvent.Invoke(new SSwipeData()
            {
                State = ESwipeState.SWIPING,
                Direction = _currentDetectedDirection,
                DirectionalMagnitude = CalculateDirectionalMagnitude(eventData.position)
            }); ;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            float directionalMagnitude = CalculateDirectionalMagnitude(eventData.position);

            _swipeEvent.Invoke(
                new SSwipeData()
                {
                    State = directionalMagnitude > _threshold ? ESwipeState.SUCCEEDED : ESwipeState.FAILED,
                    Direction = _currentDetectedDirection,
                    DirectionalMagnitude = directionalMagnitude
                }
            );
        }
        #endregion

        private float CalculateDirectionalMagnitude(Vector2 position)
        {
            switch (_currentDetectedDirection)
            {
                case ESwipeDirection.RIGHT:
                case ESwipeDirection.LEFT:
                    return Mathf.Abs(position.x - _dragStartPosition.x);
                case ESwipeDirection.DOWN:
                case ESwipeDirection.UP:
                    return Mathf.Abs(position.y - _dragStartPosition.y);
            }

            return 0;
        }

        private bool DetectDotDirectionSingleAxis(Vector2 normalizedDirection, Vector2 test, ESwipeDirection testEnum, ESwipeDirection oppositeEnum)
        {
            float dot = Vector2.Dot(test, normalizedDirection);

            // if 0, then it's either left or right. The normalized direction 
            // will exactly equal the Vector2.right or Vector2.left ( in the right left case)
            if (dot == 0)
            {
                if (normalizedDirection == test) _currentDetectedDirection = testEnum;
                else _currentDetectedDirection = oppositeEnum;
                return true;
            }

            // if it isn't 0, then work out which direction it is using the const dot
            if (dot <= 1 && dot >= cNormalizedDot45Degress)
            {
                _currentDetectedDirection = testEnum;
                return true;
            }
            else if (dot >= -1 && dot <= -cNormalizedDot45Degress)
            {
                _currentDetectedDirection = oppositeEnum;
                return true;
            }

            return false;
        }

    }
}