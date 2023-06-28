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

        private Rigidbody2D rb2D;

        private void Awake()
        {
            rb2D = transform.GetComponent<Rigidbody2D>();
            rb2D.velocity = Vector2.zero;
            rb2D.sharedMaterial = new PhysicsMaterial2D() { friction = 0, bounciness = 1f };
        }

        protected void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Box"))
            {
                BoxBase box = collision.gameObject.GetComponent<BoxBase>();
                box.Hurt(atk);
                BallSkill();
            }
        }

        private void Move(Vector2 direction)
        {
            rb2D.velocity = direction.normalized * moveSpeed;
        }

        public void SetMoveDirection(Vector2 direction)
        {
            Move(direction);
        }

        protected virtual void BallSkill()
        {
        }
    }
}
