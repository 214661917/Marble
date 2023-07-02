//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MarbleBall
{
    public class UIGameOverWnd : UIBase
    {
        private Button button;

        public override void OnInit()
        {
            base.OnInit();

            button = transform.Find("Bg/Button").GetComponent<Button>();
            button.onClick.AddListener(()=> { 
                //返回开始场景
            });
        }
    }
}
