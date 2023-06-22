//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public class BoxBase : Entity
    {
        private int hp = 1;
        public int HP
        {
            get
            {
                ShowHp();
                return hp;
            }
        }
        public TextMesh hpText;



        private void Awake()
        {
            hpText = transform.Find("HPText").GetComponent<TextMesh>();
        }

        private void OnEnable()
        {
            ShowHp();
        }

        public void Move()
        {
            transform.position -= Vector3.up * Constant.OneGridDistance;
        }

        private void Death()
        {
            BoxManager.Instance.RemoveBox(ID);
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
