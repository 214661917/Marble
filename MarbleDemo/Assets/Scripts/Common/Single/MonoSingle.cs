//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall.Common
{
    public class MonoSingle<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T instance;
        public static T Instance
        {
            get
            {
                return instance;
            }
        }

        //private void Awake()
        //{
        //    instance = this;
        //}
    }
}
