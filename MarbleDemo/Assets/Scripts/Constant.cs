//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public static class Constant
    {
        /// <summary>
        /// 场景中一格的距离
        /// </summary>
        public const float OneGridDistance = 0.9f;
        /// <summary>
        /// 场景中格子的列数
        /// </summary>
        public const int ColumnMaxCount = 5;
        /// <summary>
        /// 场景中格子的行数
        /// </summary>
        public const int RowMaxCount = 7;
        /// <summary>
        /// 备战席容量
        /// </summary>
        public const int LeisureBallCount = 10;
        /// <summary>
        /// 出战席容量
        /// </summary>
        public const int BattleBallCount = 10;
        /// <summary>
        /// 商店每次刷新出售球的数量
        /// </summary>
        public const int ShopSellCount = 5;
    }
}
