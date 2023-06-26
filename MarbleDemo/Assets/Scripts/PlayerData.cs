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
