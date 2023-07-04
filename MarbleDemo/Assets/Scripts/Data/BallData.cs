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
        //价格
        public int price;

        BallData()
        {

        }

        public BallData(int id, BallType type, int atk, float moveSpeed, int price)
        {
            this.id = id;
            this.type = type;
            this.atk = atk;
            this.moveSpeed = moveSpeed;
            this.price = price;
        }
    }
}
