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
            Dictionary<int, BoxBase> boxDic = BoxManager.Instance.BoxDic;

            foreach (var item in boxDic)
            {
                float distance = Vector2.Distance(item.Value.transform.position, blastPos);
                if (distance <= blastRange)
                {
                    targets.Add(item.Value);
                }
            }

            for (int i = 0; i < targets.Count; i++)
            {
                targets[i].Hurt(blastAtk);
            }
        }
    }
}
