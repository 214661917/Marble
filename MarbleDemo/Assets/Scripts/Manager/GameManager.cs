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

            GameInit();
        }

        private void OnDisable()
        {
            EventManager.Instance.UnRegist(EventKey.RemoveBall, OnRemoveBall);
        }

        private void GameInit()
        {
            //临时写法
            playerData.ballMaxCount = 5;

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


        public void NextRound(params object[] args)
        {
            playerData.ReplenishBall();
            BoxManager.Instance.DownMoveBox();
        }

        /// <summary>
        /// 获取一个有效的id
        /// </summary>
        public int GetAvailableId()
        {
            return ++availableId;
        }
    }
}
