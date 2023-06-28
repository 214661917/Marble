//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public class PlayerControl : MonoBehaviour
    {
        public Transform muzzle;

        private PlayerData playerData;

        //临时变量
        public BallType ballType = BallType.Blast;

        private void Start()
        {
            playerData = PlayerData.Instance;

            EventManager.Instance.Regist(EventKey.TouchDown, OnShoot);
        }

        private void OnDisable()
        {
            EventManager.Instance.UnRegist(EventKey.TouchDown, OnShoot);
        }

        private void OnShoot(params object[] args)
        {
            Vector2 touchPos = (Vector2)args[0];

            if (playerData.ballCount > 0)
            {
                Vector2 direction = Camera.main.ScreenToWorldPoint(touchPos) - muzzle.position;
                Shoot(direction);
            }
        }

        private void Shoot(Vector2 direction)
        {
            BallBase ball = BallManager.Instance.GenerateBall(ballType);
            ball.transform.position = muzzle.position;
            ball.transform.rotation = muzzle.rotation;
            ball.SetMoveDirection(direction);

            playerData.ballCount--;
        }
    }
}
