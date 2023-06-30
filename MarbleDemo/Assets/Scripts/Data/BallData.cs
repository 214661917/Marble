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

        BallData()
        {

        }

        public BallData(int id, BallType type, int atk)
        {
            this.id = id;
            this.type = type;
            this.atk = atk;
        }
    }
}
