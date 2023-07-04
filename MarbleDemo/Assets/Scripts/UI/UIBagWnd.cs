//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MarbleBall
{
    public class UIBagWnd : UIBase
    {
        Transform leisureBallRoot;
        Transform battleBallRoot;
        Button closeButton;

        List<BallCell> leisureBallList = new List<BallCell>();
        List<BallCell> battleBallList = new List<BallCell>();

        public override void OnInit()
        {
            base.OnInit();

            closeButton = transform.Find("CloseButton").GetComponent<Button>();
            closeButton.onClick.AddListener(() => {
                UIManager.Instance.PopPanel();
            });

            leisureBallRoot = transform.Find("LeisureRoot/Bg/BallRoot");
            battleBallRoot = transform.Find("BattleRoot/Bg/BallRoot");

            for (int i = 0; i < Constant.LeisureBallCount; i++)
            {
                BallCell ballCell = leisureBallRoot.Find("BallCell" + i).GetComponent<BallCell>();
                leisureBallList.Add(ballCell);
                ballCell.Init();
            }

            for (int i = 0; i < Constant.BattleBallCount; i++)
            {
                BallCell ballCell = battleBallRoot.Find("BallCell" + i).GetComponent<BallCell>();
                battleBallList.Add(ballCell);
                ballCell.Init();
            }
        }

        public override void OnEnter()
        {
            base.OnEnter();

            EventManager.Instance.Regist(EventKey.LeisureBagChange, OnLeisureBagChange);
            EventManager.Instance.Regist(EventKey.BattleBagChange, OnBattleBagChange);

            UpdataLeisureList();
            UpdateBattleList();
        }

        public override void OnExit()
        {
            base.OnExit();

            EventManager.Instance.UnRegist(EventKey.LeisureBagChange, OnLeisureBagChange);
            EventManager.Instance.UnRegist(EventKey.BattleBagChange, OnBattleBagChange);
        }

        private void OnLeisureBagChange(params object[] args)
        {
            UpdataLeisureList();
        }

        private void OnBattleBagChange(params object[] args)
        {
            UpdateBattleList();
        }

        private void UpdataLeisureList()
        {
            for (int i = 0; i < Constant.LeisureBallCount; i++)
            {
                if (BallBag.Instance.LeisureBallDic.TryGetValue(i, out BallData ballData))
                {
                    leisureBallList[i].SetBallData(ballData);
                }
            }
        }

        private void UpdateBattleList()
        {
            for (int i = 0; i < Constant.BattleBallCount; i++)
            {
                if (BallBag.Instance.BattleBallDic.TryGetValue(i, out BallData ballData))
                {
                    battleBallList[i].SetBallData(ballData);
                }
            }
        }
    }
}
