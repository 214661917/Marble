//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MarbleBall
{
    public class UIShopWnd : UIBase
    {
        public Button closeButton;

        public override void OnInit()
        {
            closeButton = transform.Find("CloseButton").GetComponent<Button>();
            closeButton.onClick.AddListener(()=> {
                UIManager.Instance.PopPanel();
            });
        }
    }
}
