//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MarbleBall
{
    public class UIGameMainWnd : UIBase
    {
        public Text moneyText;
        public Button shopButton;
        public Text shopButtonText;
        public GameObject uiShopWnd;

        public override void OnInit()
        {
            moneyText = transform.Find("MoneyText").GetComponent<Text>();
            shopButton = transform.Find("ShopButton").GetComponent<Button>();
            shopButton.onClick.AddListener(() => {
                //显示商店界面
                UIManager.Instance.PushPanel(UIType.UIShopWnd);
            });
            shopButtonText = transform.Find("ShopButton/Text").GetComponent<Text>();
            shopButtonText.text = "商店";
        }

        public override void OnEnter()
        {
            base.OnEnter();

            ShowMoney(0);

            EventManager.Instance.Regist(EventKey.MoneyChange, OnMoneyChange);
        }

        public override void OnExit()
        {
            EventManager.Instance.UnRegist(EventKey.MoneyChange, OnMoneyChange);
        }

        private void OnMoneyChange(params object[] args)
        {
            int money = (int)args[0];

            ShowMoney(money);
        }

        private void ShowMoney(int money)
        {
            moneyText.text = "金币:" + money;
        }
    }
}
