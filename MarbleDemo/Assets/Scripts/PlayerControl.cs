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

        //临时变量
        public BallType ballType = BallType.Blast;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && ballCount > 0)
            {
                Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - muzzle.position;
                Shoot(direction);
            }

            if (ballCount <= 0 && BallManager.Instance.BallDic.Count == 0)
            {
                //下一回合
                EventManager.Instance.TriggerEvent(EventKey.NextRound);
                ballCount = 2;
            }
        }

        void Shoot(Vector2 direction)
        {
            BallBase ball = BallManager.Instance.GenerateBall(ballType);
            ball.transform.position = muzzle.position;
            ball.transform.rotation = muzzle.rotation;
            ball.SetMoveDirection(direction);

            ballCount--;
        }
    }
}
