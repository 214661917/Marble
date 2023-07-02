//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarbleBall.Common;

namespace MarbleBall
{
    public class GameManager : MonoSingle<GameManager>
    {
        //可用的实体id 用于Box,Ball
        private int availableId = 0;

        private PlayerData playerData;

        private bool isGameOver;
        public bool IsGameOver
        {
            get
            {
                return isGameOver;
            }
        }
        private void Awake()
        {
            instance = this;

            playerData = PlayerData.Instance;
        }

        private void Start()
        {
            //打开游戏主界面
            UIManager.Instance.PushPanel(UIType.UIGameMainWnd);

            EventManager.Instance.Regist(EventKey.RemoveBall, OnRemoveBall);
            EventManager.Instance.Regist(EventKey.BoxCross, GameOver);

            GameInit();
        }

        private void OnDisable()
        {
            EventManager.Instance.UnRegist(EventKey.RemoveBall, OnRemoveBall);
            EventManager.Instance.UnRegist(EventKey.BoxCross, GameOver);
        }

        private void GameInit()
        {
            isGameOver = false;
            TestAddBall();
            NextRound();
        }

        private void OnRemoveBall(params object[] args)
        {
            int ballCount = (int)args[0];
            int usableBallCount = PlayerData.Instance.ballCount;

            /*下一回合的条件
             *1.没有球可以发射了
             *2.发射出去的球都销毁了
             */
            if (usableBallCount <= 0 && ballCount == 0)
            {
                //下一回合
                NextRound();
            }
        }

        public void NextRound()
        {
            playerData.ReplenishBall();
            BoxManager.Instance.DownMoveBox();
            EventManager.Instance.TriggerEvent(EventKey.NextRound);
        }

        /// <summary>
        /// 获取一个有效的id
        /// </summary>
        public int GetAvailableId()
        {
            return ++availableId;
        }

        private void GameOver(params object[] args)
        {
            if (isGameOver)
            {
                return;
            }

            Debug.Log("游戏结束");
            isGameOver = true;
            EventManager.Instance.TriggerEvent(EventKey.GameOver);
            UIManager.Instance.PushPanel(UIType.UIGameOverWnd);
        }

        //测试代码
        private void TestAddBall()
        {
            BallData ball1 = new BallData(1, BallType.Normal, 5, 10);
            BallData ball2 = new BallData(2, BallType.Blast, 5, 10);
            BallData ball3 = new BallData(3, BallType.Blast, 10, 10);

            Debug.Log(BallBagData.Instance.AddBall(ball1));
            //Debug.Log(BallBagData.Instance.AddBall(ball2));
            //Debug.Log(BallBagData.Instance.AddBall(ball3));

            BallBagData.Instance.MoveBallToBattle(0, 0);
            //BallBagData.Instance.MoveBallToBattle(1, 1);
            //BallBagData.Instance.MoveBallToBattle(2, 2);

            for (int i = 0; i < Constant.LeisureBallCount; i++)
            {
                if (BallBagData.Instance.LeisureBallDic.ContainsKey(i))
                {
                    Debug.Log(string.Format("备战席 第{0}个ID：{1}", i, BallBagData.Instance.LeisureBallDic[i].id));
                }
            }

            for (int i = 0; i < Constant.BattleBallCount; i++)
            {
                if (BallBagData.Instance.BattleBallDic.ContainsKey(i))
                {
                    Debug.Log(string.Format("出战席 第{0}个ID：{1}", i, BallBagData.Instance.BattleBallDic[i].id));
                }
            }
        }
    }
}
