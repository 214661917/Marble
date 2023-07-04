//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public class BoxBase : Entity
    {
        private int hp = 10;
        public int HP
        {
            get
            {
                ShowHp();
                return hp;
            }
            set
            {
                hp = value;
                ShowHp();
            }
        }
        public TextMesh hpText;

        private int cost = 1;
        //箱子的位置层数 从上往下0-n
        private int boxLayer = 0;

        public int Cost
        {
            get
            {
                return cost;
            }
        }

        private void Awake()
        {
            hpText = transform.Find("HPText").GetComponent<TextMesh>();
        }

        public void Move()
        {
            transform.position -= Vector3.up * Constant.OneGridDistance;

            //箱子超过边界
            if (++boxLayer > Constant.RowMaxCount)
            {
                EventManager.Instance.TriggerEvent(EventKey.BoxCross);
            }
        }

        private void Death()
        {
            BoxManager.Instance.RemoveBox(ID);
            PlayerData.Instance.AddMoney(Cost);
            Destroy(gameObject);
        }

        private void ShowHp()
        {
            hpText.text = hp.ToString();
        }

        public void Hurt(int atk)
        {
            hp -= atk;

            ShowHp();

            if (hp <= 0)
            {
                Death();
            }
        }
    }
}
