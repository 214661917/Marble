//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public class Entity : MonoBehaviour
    {
        protected int id = 0;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }
}
