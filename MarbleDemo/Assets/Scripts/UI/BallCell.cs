//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MarbleBall
{
    public class BallCell : MonoBehaviour
    {
        private BallData ballData;
        private Text text;

        public void Init()
        {
            SetText("");
        }

        public void SetBallData(BallData data)
        {
            ballData = data;

            SetText(ballData.id.ToString());
        }

        private void SetText(string str)
        {
            if (text == null)
            {
                text = transform.Find("Text").GetComponent<Text>();
            }

            text.text = str;
        }
    }
}
