//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarbleBall
{
    public partial class UIManager
    {
        /// <summary>
        /// 初始化UI界面的预制体路径 Resources下
        /// </summary>
        void InitPath()
        {
            pathDic = new Dictionary<string, string>();

            pathDic.Add(UIType.UIGameMainWnd, "Prefabs/UI/UIGameMainWnd");
            pathDic.Add(UIType.UIShopWnd, "Prefabs/UI/UIShopWnd");
            pathDic.Add(UIType.UIGameOverWnd, "Prefabs/UI/UIGameOverWnd");
            pathDic.Add(UIType.UIBagWnd, "Prefabs/UI/UIBagWnd");
        }

        /// <summary>
        /// 初始化UI层级和对应的界面名字
        /// </summary>
        void InitUILayer()
        {
            layerNameDic = new Dictionary<UILayer, string>();

            layerNameDic.Add(UILayer.Back, "Back");
            layerNameDic.Add(UILayer.Default, "Default");
            layerNameDic.Add(UILayer.Pop, "Pop");
            layerNameDic.Add(UILayer.Top, "Top");
        }
    }
}
