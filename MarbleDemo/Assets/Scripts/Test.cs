//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public class Test : MonoBehaviour
    {
        private void Awake()
        {
            EventManager.Instance.Regist(EventKey.TestEvent, TestFunc);
        }

        private void Start()
        {
            List<string> list = new List<string>();
            list.Add("A");
            list.Add("B");
            list.Add("C");
            EventManager.Instance.TriggerEvent(EventKey.TestEvent, list);
        }

        void TestFunc(params object[] args)
        {
            List<string> list = (List<string>)args[0];
            for (int i = 0; i < list.Count; i++)
            {
                Debug.Log(string.Format("触发事件{0}", list[i]));
            }
        }
    }
}
