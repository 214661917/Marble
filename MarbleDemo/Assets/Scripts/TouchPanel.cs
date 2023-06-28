//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MarbleBall
{
    public class TouchPanel : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            EventManager.Instance.TriggerEvent(EventKey.TouchDown, eventData.position);
        }
    }
}
