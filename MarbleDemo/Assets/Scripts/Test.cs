//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public class Test : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Buy();
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                Read();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Refresh();
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                Battle();
            }

        }
        private void Buy()
        {
            BallShop.Instance.BuyBall(1);
            Debug.Log("===================购买=======================");
        }

        private void Read()
        {
            Debug.Log("===================商店=======================");
            for (int i = 0; i < Constant.ShopSellCount; i++)
            {
                if (BallShop.Instance.SellDic.ContainsKey(i))
                {
                    BallData ballData = BallShop.Instance.SellDic[i];
                    Debug.Log(string.Format("SellList:{0},ID:{1}", i, ballData.id));
                }
            }

            Debug.Log("===================备战席=======================");
            for (int i = 0; i < Constant.LeisureBallCount; i++)
            {
                if (BallBag.Instance.LeisureBallDic.ContainsKey(i))
                {
                    BallData ballData = BallBag.Instance.LeisureBallDic[i];
                    Debug.Log(string.Format("备战席:{0},ID:{1}", i, ballData.id));
                }
            }
            Debug.Log("===================出战席=======================");
            for (int i = 0; i < Constant.BattleBallCount; i++)
            {
                if (BallBag.Instance.BattleBallDic.ContainsKey(i))
                {
                    BallData ballData = BallBag.Instance.BattleBallDic[i];
                    Debug.Log(string.Format("出战席:{0},ID:{1}", i, ballData.id));
                }
            }
        }

        private void Refresh()
        {
            BallShop.Instance.Refresh();
            Debug.Log("===================刷新商店=======================");
        }


        private void Battle()
        {
            BallBag.Instance.MoveBallToBattle(0, 0);
            Debug.Log("===================上阵=======================");

        }
    }
}
