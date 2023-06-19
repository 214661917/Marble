//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public interface IBlastEffect
    {
        public static void Blast(Vector3 blastPos, float blastRange, int blastAtk)
        {
            List<BoxBase> targets = new List<BoxBase>();
            List<BoxBase> boxList = BoxManager.Instance.BoxList;

            for (int i = 0; i < boxList.Count; i++)
            {
                float distance = Vector2.Distance(boxList[i].transform.position, blastPos);
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
