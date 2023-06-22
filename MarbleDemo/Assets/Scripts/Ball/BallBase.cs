//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public class BallBase : Entity
    {
        public float moveSpeed = 10;
        public int atk = 1;

        public Vector2 moveDir = Vector2.up;

        private Rigidbody2D rigidbody;

        private void Awake()
        {
            rigidbody = transform.GetComponent<Rigidbody2D>();
        }

        protected void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag != "Ball")
            {
                Vector2 direction = Vector2.Reflect(moveDir, collision.GetContact(0).normal);
                SetMoveDirection(direction);
            }
            
            if (collision.gameObject.tag == "Box")
            {
                BoxBase box = collision.gameObject.GetComponent<BoxBase>();
                box.Hurt(atk);
                BallSkill();
            }
        }

        void Move()
        {
            rigidbody.velocity = moveDir.normalized * moveSpeed;
        }

        public void SetMoveDirection(Vector2 direction)
        {
            moveDir = direction;
            Move();
        }

        protected virtual void BallSkill()
        {
        }
    }
}
