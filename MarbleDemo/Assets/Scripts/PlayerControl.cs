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

        private GameObject ballPrefab;

        private void Awake()
        {
            ballPrefab = Resources.Load<GameObject>("Prefabs/Ball");
        }

        private void Start()
        {


        }

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
            GameObject obj = Instantiate(ballPrefab, muzzle.position, muzzle.rotation);
            BallBase ball= obj.GetComponent<BallBase>();
            ball.SetMoveDirection(direction);

            ball.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        }
    }
}
