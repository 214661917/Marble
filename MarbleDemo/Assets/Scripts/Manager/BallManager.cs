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
        private void Awake()
        {
            instance = this;

            ballPrefabs.Add(BallType.Normal, Resources.Load<GameObject>("Prefabs/Balls/Ball"));
            ballPrefabs.Add(BallType.Blast, Resources.Load<GameObject>("Prefabs/Balls/BlastBall"));
        }

        public GameObject GetBall(BallType ballType)
        {
            if (!ballPrefabs.ContainsKey(ballType) || !ballPrefabs[ballType])
            {
                return null;
            }

            GameObject ball = Instantiate(ballPrefabs[ballType]);
            switch (ballType)
            {
                case BallType.Blast:
                    ball.AddComponent<BlastBall>();
                    break;
                default:
                    ball.AddComponent<BallBase>();
                    break;
            }

            return ball;
        }
    }
}
