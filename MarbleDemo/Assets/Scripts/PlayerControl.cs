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
                Shoot();
            }
        }

        void Shoot()
        {
            Instantiate(ballPrefab, muzzle.position, muzzle.rotation);
        }
    }
}
