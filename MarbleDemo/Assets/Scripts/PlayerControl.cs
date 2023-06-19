//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public class PlayerControl : MonoBehaviour
    {
        public Transform muzzle;

        public int ballCount = 2;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - muzzle.position;
                Shoot(direction);
            }
        }

        void Shoot(Vector2 direction)
        {
            GameObject ballObj = BallManager.Instance.GetBall(BallType.Blast);
            ballObj.transform.position = muzzle.position;
            ballObj.transform.rotation = muzzle.rotation;

            BallBase ball= ballObj.GetComponent<BallBase>();
            ball.SetMoveDirection(direction);
        }
    }
}
