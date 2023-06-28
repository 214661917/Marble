//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public class BlastBall : BallBase, IBlastEffect
    {
        public float blastRange = 2;
        public int blastAtk = 1;
        protected override void BallSkill()
        {
            IBlastEffect.Blast(transform.position, blastRange, blastAtk);
        }
    }
}
