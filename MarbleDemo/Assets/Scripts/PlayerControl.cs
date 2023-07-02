//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public class PlayerControl : MonoBehaviour
    {
        public Transform muzzle;

        private List<BallData> ballDatas;
        private int curBallIndex = 0;

        private PlayerData playerData;
        private BallBagData bagData;

        //临时变量
        public BallType ballType = BallType.Blast;

        private void Start()
        {
            playerData = PlayerData.Instance;
            bagData = BallBagData.Instance;

            EventManager.Instance.Regist(EventKey.TouchDown, OnShoot);
            EventManager.Instance.Regist(EventKey.BattleBagChange, GetBallList);
            EventManager.Instance.Regist(EventKey.NextRound, OnNextRound);
        }

        private void OnDisable()
        {
            EventManager.Instance.UnRegist(EventKey.TouchDown, OnShoot);
            EventManager.Instance.UnRegist(EventKey.BattleBagChange, GetBallList);
            EventManager.Instance.UnRegist(EventKey.NextRound, OnNextRound);
        }

        private void OnShoot(params object[] args)
        {
            Vector2 touchPos = (Vector2)args[0];

            if (playerData.ballCount > 0)
            {
                Vector2 direction = Camera.main.ScreenToWorldPoint(touchPos) - muzzle.position;
                Shoot(direction);
            }
        }

        private void Shoot(Vector2 direction)
        {
            if (ballDatas == null)
            {
                GetBallList();
            }

            BallData ballData = ballDatas[curBallIndex++];
            BallBase ball = BallManager.Instance.GenerateBall(ballData);
            ball.transform.position = muzzle.position;
            ball.transform.rotation = muzzle.rotation;
            ball.SetMoveDirection(direction);

            playerData.ballCount--;
        }

        private void OnNextRound(params object[] args)
        {
            //重置发射球的索引
            curBallIndex = 0;
        }

        /// <summary>
        /// 获取出战席的球
        /// </summary>
        /// <param name="args"></param>
        private void GetBallList(params object[] args)
        {
            if (ballDatas == null)
            {
                ballDatas = new List<BallData>();
            }
            else
            {
                ballDatas.Clear();
            }

            for (int i = 0; i < Constant.BattleBallCount; i++)
            {
                if (bagData.BattleBallDic.TryGetValue(i, out BallData ballData))
                {
                    ballDatas.Add(ballData);
                }
            }

            //for (int i = 0; i < ballDatas.Count; i++)
            //{
            //    Debug.Log(string.Format("第{0}个ID:{1}", i, ballDatas[i].id));
            //}
        }
    }
}
