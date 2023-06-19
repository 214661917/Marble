//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarbleBall.Common;

namespace MarbleBall
{
    public class BoxManager : MonoSingle<BoxManager>
    {
        public List<BoxBase> boxList = new List<BoxBase>();
        public List<BoxBase> BoxList
        {
            get
            {
                return boxList;
            }
        }

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            //临时写法
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Box");
            for (int i = 0; i < objects.Length; i++)
            {
                boxList.Add(objects[i].GetComponent<BoxBase>());
            }
        }

        public void BoxDeath(BoxBase box)
        {
            boxList.Remove(box);
        }
    }
}
