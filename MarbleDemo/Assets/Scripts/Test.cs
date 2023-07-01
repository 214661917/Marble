//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            BallData ball1 = new BallData(1, BallType.Normal, 5, 10);
            BallData ball2 = new BallData(2, BallType.Blast, 5, 10);
            BallData ball3 = new BallData(3, BallType.Blast, 10, 10);

            Debug.Log(BallBagData.Instance.AddBall(ball1));
            Debug.Log(BallBagData.Instance.AddBall(ball2));
            Debug.Log(BallBagData.Instance.AddBall(ball3));

            BallBagData.Instance.MoveBallToBattle(0, 0);
            BallBagData.Instance.MoveBallToBattle(1, 1);
            BallBagData.Instance.MoveBallToBattle(2, 2);

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
