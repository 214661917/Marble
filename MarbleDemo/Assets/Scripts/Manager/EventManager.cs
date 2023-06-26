//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarbleBall.Common;

namespace MarbleBall
{
    public class EventManager : MonoAutoSingle<EventManager>
    {
        //执行事件，参数为对象列表
        public delegate void EventDelegate(object[] args);
        Dictionary<EventKey, Dictionary<int, EventDelegate>> eventListeners = new Dictionary<EventKey, Dictionary<int, EventDelegate>>();

        /// <summary>
        /// 订阅事件
        /// </summary>
        /// <param name="eventKey"></param>
        /// <param name="handler"></param>
        public void Regist(EventKey eventKey, EventDelegate handler)
        {
            if (handler == null)
            {
                return;
            }

            //如果事件字典中不包含该eventKey这个键，则创建一个键值对
            if (!eventListeners.TryGetValue(eventKey, out Dictionary<int, EventDelegate> eventDic))
            {
                eventDic = new Dictionary<int, EventDelegate>();
                eventListeners.Add(eventKey, eventDic);
            }

            int handlerHash = handler.GetHashCode();

            //如果输入事件对应的字典中包含执行事件，则从中移除
            if (eventDic.ContainsKey(handlerHash))
            {
                eventDic.Remove(handlerHash);
            }

            eventDic.Add(handlerHash, handler);
        }

        /// <summary>
        /// 注销事件
        /// </summary>
        /// <param name="eventKey"></param>
        /// <param name="handler"></param>
        public void UnRegist(EventKey eventKey, EventDelegate handler)
        {
            if (handler == null)
            {
                return;
            }

            //如果事件字典中包含eventKey这个ID,则移除该键中对应的字典中的输入的执行事件
            if (eventListeners.TryGetValue(eventKey, out Dictionary<int, EventDelegate> eventDic))
            {
                eventDic.Remove(handler.GetHashCode());
                //在移除后，如果eventKey对应的字典为空，或者不存在，则删除该键值对 
                if (eventDic == null || eventDic.Count == 0)
                {
                    eventListeners.Remove(eventKey);
                }
            }
        }

        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="eventKey"></param>
        public void TriggerEvent(EventKey eventKey, params object[] args)
        {
            if (eventListeners.TryGetValue(eventKey, out Dictionary<int, EventDelegate> eventDic))
            {
                if (eventDic == null || eventDic.Count == 0)
                {
                    return;
                }

                //执行回调
                foreach (var item in eventDic)
                {
                    try
                    {
                        item.Value(args);
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 清理事件
        /// </summary>
        public void CleanEvent(EventKey eventKey)
        {
            if (eventListeners.ContainsKey(eventKey))
            {
                eventListeners.Remove(eventKey);
            }
        }
    }
}
