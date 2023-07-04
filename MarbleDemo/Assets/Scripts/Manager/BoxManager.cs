//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarbleBall.Common;

namespace MarbleBall
{
    public class BoxManager : MonoSingle<BoxManager>
    {
        Dictionary<BoxType, GameObject> boxPrefabs = new Dictionary<BoxType, GameObject>();
        readonly Dictionary<int, BoxBase> boxDic = new Dictionary<int, BoxBase>();
        public Dictionary<int, BoxBase> BoxDic
        {
            get
            {
                return boxDic;
            }
        }

        int minBoxHp = 5;
        int maxBoxHp = 10;
        float[] boxColumnPos = new float[] { -1.8f, -0.9f, 0, 0.9f, 1.8f };
        Transform boxRefreshPoint;

        private void Awake()
        {
            instance = this;

            boxRefreshPoint = GameObject.Find("BoxRefreshPoint").transform;

            InitPrefab();
        }

        private void InitPrefab()
        {
            boxPrefabs.Add(BoxType.Normal, Resources.Load<GameObject>("Prefabs/Box/Box"));
        }

        private void MoveAllBox()
        {
            foreach (var item in boxDic)
            {
                item.Value.Move();
            }
        }

        private void GenerateRowBox()
        {
            for (int i = 0; i < Constant.ColumnMaxCount; i++)
            {
                BoxBase box = GenerateBox(BoxType.Normal);
                box.transform.position = new Vector2(boxColumnPos[i], boxRefreshPoint.position.y);
            }
        }

        private BoxBase GenerateBox(BoxType boxType)
        {
            if (!boxPrefabs.ContainsKey(boxType) || !boxPrefabs[boxType])
            {
                return null;
            }

            GameObject boxObj = Instantiate(boxPrefabs[boxType]);
            BoxBase box;
            switch (boxType)
            {
                default:
                    box = boxObj.AddComponent<BoxBase>();
                    break;
            }

            int addHp = GameManager.Instance.RoundCount - 1;
            box.HP = Random.Range(minBoxHp + addHp, maxBoxHp + addHp);
            box.ID = GameManager.Instance.GetAvailableId();
            boxDic.Add(box.ID, box);

            return box;
        }

        public void RemoveBox(int boxId)
        {
            boxDic.Remove(boxId);
        }

        public void DownMoveBox()
        {
            GenerateRowBox();
            MoveAllBox();
        }
    }
}
