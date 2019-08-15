using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Fjord.Common.BroadcastSystem
{
    [RequireComponent(typeof(Animator))]
    public class AnimationBroadcaster : MonoBehaviour
    {
        private void BroadcastAnimationEvent(string eventName)
        {
            BroadcastSystem.instance.Broadcast(eventName, null);
        }
    }
}
