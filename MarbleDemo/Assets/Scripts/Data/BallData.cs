//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public class BallData
    {
        public int id;
        public BallType type;
        public int atk;
        public float moveSpeed;

        BallData()
        {

        }

        public BallData(int id, BallType type, int atk, float moveSpeed)
        {
            this.id = id;
            this.type = type;
            this.atk = atk;
            this.moveSpeed = moveSpeed;
        }
    }
}
