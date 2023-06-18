//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public class BlastBall : BallBase
    {
        public float blastRange = 2;
        public int blastAtk = 10;
        public List<BoxBase> targets = new List<BoxBase>();
        protected override void BallSkill()
        {
            List<BoxBase> boxList = BoxManager.Instance.BoxList;
            for (int i = 0; i < boxList.Count; i++)
            {
                float distance = Vector2.Distance(boxList[i].transform.position, transform.position);
                Debug.Log(distance);
                if (distance <= blastRange)
                {
                    targets.Add(boxList[i]);
                }
            }

            for (int i = 0; i < targets.Count; i++)
            {
                targets[i].Hurt(blastAtk);
            }
        }
    }
}
