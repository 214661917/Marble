//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public class BallControl : MonoBehaviour
    {
        public float moveSpeed = 10;
        

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("碰撞墙体1");
            //Vector2 Reflect
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            Debug.Log("碰撞墙体2");
        }

        //private void Update()
        //{
        //    transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
        //}
    }
}
