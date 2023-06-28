//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarbleBall.Common;

namespace MarbleBall
{
    public class PlayerData : MonoAutoSingle<PlayerData>
    {
        public int money = 0;
        /// <summary>
        /// 当前游戏可发射的球的数量
        /// </summary>
        public int ballCount = 0;
        /// <summary>
        /// 当前游戏可发射球的上限
        /// </summary>
        public int ballMaxCount = 0;

        public void ResetData()
        {
            money = 0;
            ballCount = 0;
            ballMaxCount = 0;
        }

        /// <summary>
        /// 球补满至上限
        /// </summary>
        public void ReplenishBall()
        {
            ballCount = ballMaxCount;
        }

        public void AddMoney(int count)
        {
            money += count;
            EventManager.Instance.TriggerEvent(EventKey.MoneyChange, money);
        }

        public bool ExpendMoney(int count)
        {
            if (money < count)
            {
                return false;
            }
            
            money -= count;
            EventManager.Instance.TriggerEvent(EventKey.MoneyChange, money);

            return false;
        }
    }
}
