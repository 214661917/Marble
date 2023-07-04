//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarbleBall.Common;

namespace MarbleBall
{
    public class BallShop : Single<BallShop>
    {
        //抽取池 用于抽取可购买的球
        List<BallData> ballPool;
        //存放可购买的球
        private readonly Dictionary<int, BallData> sellList = new Dictionary<int, BallData>();
        public Dictionary<int, BallData> SellDic
        {
            get
            {
                return sellList;
            }
        }

        public void Init()
        {
            ballPool = new List<BallData>();

            //临时写法 后续读表
            ballPool.Add(new BallData(1, BallType.Normal, 1, 10, 2));
            ballPool.Add(new BallData(2, BallType.Normal, 2, 10, 2));
            ballPool.Add(new BallData(3, BallType.Blast, 3, 10, 3));
            ballPool.Add(new BallData(4, BallType.Blast, 4, 10, 3));
            ballPool.Add(new BallData(5, BallType.Normal, 5, 10, 4));
            ballPool.Add(new BallData(6, BallType.Normal, 6, 10, 4));
            ballPool.Add(new BallData(7, BallType.Normal, 7, 10, 5));
            ballPool.Add(new BallData(8, BallType.Normal, 8, 10, 5));
            ballPool.Add(new BallData(9, BallType.Normal, 9, 10, 6));
            ballPool.Add(new BallData(10, BallType.Normal, 10, 10, 6));
        }

        public bool BuyBall(int index)
        {
            if (!sellList.TryGetValue(index, out BallData ball))
            {
                return false;
            }

            //钱不够
            if (PlayerData.Instance.money < ball.price)
            {
                return false;
            }

            //购买成功
            if (BallBag.Instance.AddBall(ball))
            {
                sellList.Remove(index);
                PlayerData.Instance.money -= ball.price;
                return true;
            }

            return false;
        }

        /// <summary>
        /// 刷新可购买的球
        /// </summary>
        public void Refresh()
        {
            sellList.Clear();

            //随机获得n个球添加至sellList
            for (int i = 0; i < Constant.ShopSellCount; i++)
            {
                BallData ball = ballPool[Random.Range(0, ballPool.Count)];
                sellList.Add(i, ball);
            }
        }
    }
}
