//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarbleBall.Common;

namespace MarbleBall
{
    public class BallManager : MonoSingle<BallManager>
    {
        Dictionary<BallType, GameObject> ballPrefabs = new Dictionary<BallType, GameObject>();
        readonly Dictionary<int, BallBase> ballDic = new Dictionary<int, BallBase>();
        public Dictionary<int, BallBase> BallDic
        {
            get
            {
                return ballDic;
            }
        }
        private void Awake()
        {
            instance = this;

            EventManager.Instance.Regist(EventKey.RemoveBall, RemoveBall);

            ballPrefabs.Add(BallType.Normal, Resources.Load<GameObject>("Prefabs/Balls/Ball"));
            ballPrefabs.Add(BallType.Blast, Resources.Load<GameObject>("Prefabs/Balls/BlastBall"));
        }

        private void OnDestroy()
        {
            EventManager.Instance.UnRegist(EventKey.RemoveBall, RemoveBall);
        }

        public BallBase GenerateBall(BallType ballType)
        {
            if (!ballPrefabs.ContainsKey(ballType) || !ballPrefabs[ballType])
            {
                return null;
            }

            GameObject ballObj = Instantiate(ballPrefabs[ballType]);
            BallBase ball;
            switch (ballType)
            {
                case BallType.Blast:
                    ball = ballObj.AddComponent<BlastBall>();
                    break;
                default:
                    ball = ballObj.AddComponent<BallBase>();
                    break;
            }

            ball.ID = GameManager.Instance.GetAvailableId();
            ballDic.Add(ball.ID, ball);

            return ball;
        }

        /// <summary>
        /// 球从场景中移除
        /// </summary>
        /// <param name="ballId"></param>
        public void RemoveBall(params object[] args)
        {
            int ballId = (int)args[0];
            BallBase ball = ballDic[ballId];
            ballDic.Remove(ballId);
            Destroy(ball.gameObject);
        }
    }
}
