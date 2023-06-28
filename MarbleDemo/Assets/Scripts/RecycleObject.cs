//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public class RecycleObject : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Ball"))
            {
                BallBase ball = collision.GetComponent<BallBase>();
                BallManager.Instance.RemoveBall(ball.ID);
            }
        }
    }
}
