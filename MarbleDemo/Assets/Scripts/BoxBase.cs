//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public class BoxBase : MonoBehaviour
    {
        public int hp = 10;

        public void Hurt(int atk)
        {
            hp -= atk;
            if (hp <= 0)
            {
                Death();
            }
        }

        void Death()
        {
            BoxManager.Instance.BoxDeath(this);
            Destroy(gameObject);
        }
    }
}
