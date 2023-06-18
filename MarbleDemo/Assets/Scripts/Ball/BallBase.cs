//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public class BallBase : MonoBehaviour
    {
        public float moveSpeed = 10;
        public int atk = 1;

        public Vector2 moveDir = Vector2.up;

        protected void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag != "Ball")
            {
                moveDir = Vector2.Reflect(moveDir, collision.GetContact(0).normal);
            }
            
            if (collision.gameObject.tag == "Box")
            {
                BoxBase box = collision.gameObject.GetComponent<BoxBase>();
                box.Hurt(atk);
                BallSkill();
            }
        }

        private void Update()
        {
            transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);
        }

        public void SetMoveDirection(Vector2 direction)
        {
            moveDir = direction;
        }

        protected virtual void BallSkill()
        {
        }
    }
}
