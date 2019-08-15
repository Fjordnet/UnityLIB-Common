using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Fjord.Common.Services
{
    [RequireComponent(typeof(Animator))]
    public class AnimationBroadcaster : MonoBehaviour
    {
        private void BroadcastAnimationEvent(string eventName)
        {
            EventDispatcher.instance.Dispatch(eventName, null);
        }
    }
}
