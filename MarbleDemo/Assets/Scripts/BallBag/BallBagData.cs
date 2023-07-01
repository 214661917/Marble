//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarbleBall.Common;

namespace MarbleBall
{
    public class BallBagData : Single<BallBagData>
    {
        //备战席 key:在容器中的位置索引
        private readonly Dictionary<int, BallData> leisureBallDic = new Dictionary<int, BallData>();
        public Dictionary<int, BallData> LeisureBallDic
        {
            get
            {
                return leisureBallDic;
            }
        }
        //出战席 key:在容器中的位置索引
        private readonly Dictionary<int, BallData> battleBallDic = new Dictionary<int, BallData>();

        public Dictionary<int, BallData> BattleBallDic
        {
            get
            {
                return battleBallDic;
            }
        }

        //获得球 返回是否添加成功
        public bool AddBall(BallData ball)
        {
            //先尝试添加至备战席，如果已满测尝试添加至出战席
            return AddBallToLeisure(ball) || AddBallToBattle(ball);
        }

        /// <summary>
        /// 添加球至目标字典 返回是否添加成功
        /// </summary>
        /// <param name="ball"></param>
        /// <param name="targetDic">目标字典</param>
        /// <param name="capacity">字典最大容量</param>
        /// <returns></returns>
        private bool AddBallToDic(BallData ball, Dictionary<int, BallData> targetDic, int capacity)
        {
            if (targetDic.Count >= capacity)
            {
                return false;
            }

            //从0开始找到第一个空位存入
            for (int i = 0; i < capacity - 1; i++)
            {
                if (!targetDic.ContainsKey(i))
                {
                    int index = i;
                    targetDic.Add(index, ball);
                    return true;
                }
            }

            return false;
        }

        //添加球至备战席
        public bool AddBallToLeisure(BallData ball)
        {
            if (AddBallToDic(ball, leisureBallDic, Constant.LeisureBallCount))
            {
                EventManager.Instance.TriggerEvent(EventKey.LeisureBagChange);
                PlayerData.Instance.ballMaxCount = leisureBallDic.Count;
                return true;
            }

            return false;
        }

        //添加球至出战席
        public bool AddBallToBattle(BallData ball)
        {
            if (AddBallToDic(ball, battleBallDic, Constant.BattleBallCount))
            {
                EventManager.Instance.TriggerEvent(EventKey.BattleBagChange);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 从某个字典移除球
        /// </summary>
        /// <param name="targetDic"></param>
        /// <param name="index"></param>
        private void RemoveBall(Dictionary<int, BallData> targetDic, int index)
        {
            if (targetDic.ContainsKey(index))
            {
                targetDic.Remove(index);
            }
        }

        /// <summary>
        /// 删除备战席的球
        /// </summary>
        /// <param name="index"></param>
        public void RemoveBallLeisure(int index)
        {
            RemoveBall(leisureBallDic, index);
            EventManager.Instance.TriggerEvent(EventKey.LeisureBagChange);
            PlayerData.Instance.ballMaxCount = leisureBallDic.Count;
        }

        /// <summary>
        /// 删除出战席的球
        /// </summary>
        /// <param name="index"></param>
        public void RemoveBallBattle(int index)
        {
            RemoveBall(battleBallDic, index);
            EventManager.Instance.TriggerEvent(EventKey.BattleBagChange);
        }

        /// <summary>
        /// 移动目标球至目标字典
        /// </summary>
        /// <param name="fromDic"></param>
        /// <param name="fromIndex"></param>
        /// <param name="toDic"></param>
        /// <param name="toIndex"></param>
        /// <returns></returns>
        private bool MoveBall(Dictionary<int, BallData> fromDic, int fromIndex, Dictionary<int, BallData> toDic, int toIndex)
        {
            //没找到目标球
            if (!fromDic.TryGetValue(fromIndex, out BallData tragetBall))
            {
                return false;
            }

            //目标位置有球
            if (toDic.ContainsKey(toIndex))
            {
                //交换球
                fromDic[fromIndex] = toDic[toIndex];
                toDic[toIndex] = tragetBall;
            }
            //目标位置是空位
            else
            {
                fromDic.Remove(fromIndex);
                toDic[toIndex] = tragetBall;
            }

            return true;
        }

        /// <summary>
        /// 从出战席移至备战席
        /// </summary>
        /// <param name="fromIndex"></param>
        /// <param name="toIndex"></param>
        public void MoveBallToLeisure(int fromIndex, int toIndex)
        {
            MoveBall(battleBallDic, fromIndex, leisureBallDic, toIndex);
            EventManager.Instance.TriggerEvent(EventKey.LeisureBagChange);
            PlayerData.Instance.ballMaxCount = leisureBallDic.Count;
        }

        /// <summary>
        /// 从备战席移至出战席
        /// </summary>
        /// <param name="fromIndex"></param>
        /// <param name="toIndex"></param>
        public void MoveBallToBattle(int fromIndex, int toIndex)
        {
            MoveBall(leisureBallDic, fromIndex, battleBallDic, toIndex);
            EventManager.Instance.TriggerEvent(EventKey.BattleBagChange);
        }

        //合成球 如：俩个一星合成一个二星
        private void Compound()
        {

        }
    }
}
