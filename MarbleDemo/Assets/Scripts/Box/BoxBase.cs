//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public class BoxBase : MonoBehaviour
    {
        public int hp = 10;

        void Move()
        {
            transform.position -= Vector3.up * Constant.OneGridDistance;
        }

        void Death()
        {
            BoxManager.Instance.BoxDeath(this);
            Destroy(gameObject);
        }

        public void Hurt(int atk)
        {
            hp -= atk;
            if (hp <= 0)
            {
                Death();
            }
        }
    }
}
