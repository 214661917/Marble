//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarbleBall.Common;

namespace MarbleBall
{
    public class GameManager : MonoSingle<GameManager>
    {
        /// <summary>
        /// 是否回合结束
        /// </summary>
        bool isRoundOver = true;
        /// <summary>
        /// 当前回合数
        /// </summary>
        int curRoundCount = 0;

        int availableId = 0;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            NextRound();
        }

        /*下一回合的条件
         *1.没有球可以发射了
         *2.发射出去的球都销毁了
         */
        public void NextRound()
        {
            BoxManager.Instance.DownMoveBox();
            curRoundCount++;
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
