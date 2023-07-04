//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public enum EventKey
    {
        NextRound,          //游戏下回合
        RemoveBall,         //从场景中移除球
        MoneyChange,        //钱币数量变更
        TouchDown,          //触控区按下
        BattleBagChange,    //出战席改变
        LeisureBagChange,   //备战席改变
        GameOver,           //游戏结束
        BoxCross,           //箱子越界
        BuyBall,            //购买球
        SellBall,           //出售球
    }
}
