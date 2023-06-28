//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public abstract class UIBase : MonoBehaviour
    {
        //UI层级，根据层级设置父节点
        public UILayer uiLayer;
        //UI类型
        public string uiType;

        /// <summary>
        /// 界面打开时调用
        /// </summary>
        public virtual void OnEnter()
        {
            //设置父节点
        }

        /// <summary>
        /// 界面停止时调用
        /// </summary>
        public virtual void OnPause()
        {

        }

        /// <summary>
        /// 界面恢复时调用
        /// </summary>
        public virtual void OnResume()
        {

        }

        /// <summary>
        /// 界面退出时嗲用
        /// </summary>
        public virtual void OnExit()
        {

        }
    }
}
