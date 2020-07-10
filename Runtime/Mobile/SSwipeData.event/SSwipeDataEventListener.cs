using HexUN.Events;
using UnityEngine;
using UnityEngine.Events;

namespace HexUN.UXUI
{
   [System.Serializable]
   public class SSwipeDataUnityEventListener : UnityEvent<SSwipeData>
   {
   }

   [AddComponentMenu("HexUN/UX/Mobile/Events/SSwipeDataEventListener")]
   public class SSwipeDataEventListener : ScriptableObjectEventListener<SSwipeData, SSwipeDataEvent, SSwipeDataUnityEventListener>
   {
   }
}