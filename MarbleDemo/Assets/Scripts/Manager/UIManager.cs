//Writer：LinWeiYi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarbleBall.Common;

namespace MarbleBall
{
    public partial class UIManager : MonoAutoSingle<UIManager>
    {
        //所有UI界面的prefab的路径 key:UIType value:Resources下prefab路径
        public Dictionary<string, string> pathDic;
        //加载好的UI界面
        public Dictionary<string, UIBase> panelDic;
        //所有打开的UI界面
        private Stack<UIBase> panelStack;
        //场景中的Canvas
        public Transform canvasRoot;
        //所有的UI层级节点
        public Dictionary<UILayer, Transform> layerDic;
        //UI层级对应的名字
        public Dictionary<UILayer, string> layerNameDic;

        private UIManager()
        {
            InitPath();
            InitUILayer();
        }

        public void Awake()
        {
            canvasRoot = GameObject.Find("Canvas").transform;
            LoadLayer();
        }

        private void LoadLayer()
        {
            layerDic = new Dictionary<UILayer, Transform>();
            for (int i = 0; i < layerNameDic.Count; i++)
            {
                UILayer uiLayer = (UILayer)i;
                GameObject layerObj = new GameObject(layerNameDic[uiLayer]);
                layerObj.transform.SetParent(canvasRoot);
                layerDic.Add(uiLayer, layerObj.transform);
            }
        }

        //根据类型克隆一个panel预制体 返回UIBase
        private UIBase GetPanel(string uiType)
        {
            if (panelDic == null)
            {
                panelDic = new Dictionary<string, UIBase>();
            }

            if (!panelDic.TryGetValue(uiType, out UIBase panel))
            {
                if (!pathDic.TryGetValue(uiType, out string path))
                {
                    return null;
                }

                GameObject panelPrefab = Resources.Load<GameObject>(path);
                GameObject panelObj = Instantiate(panelPrefab, canvasRoot);
                panel = panelObj.AddComponent<UIBase>();
                panelDic.Add(uiType, panel);
            }

            return panel;
        }

        /// <summary>
        /// 打开UI界面
        /// </summary>
        public void PushPanel(string uiType)
        {
            if (panelStack == null)
            {
                panelStack = new Stack<UIBase>();
            }

            //暂停上一界面
            if (panelStack.Count > 0)
            {
                UIBase topPanel = panelStack.Peek();
                topPanel.OnPause();
            }

            UIBase panel = GetPanel(uiType);
            panelStack.Push(panel);
            panel.OnEnter();
        }

        /// <summary>
        /// 关闭最上层界面
        /// </summary>
        public void PopPanel()
        {
            if (panelStack == null)
            {
                panelStack = new Stack<UIBase>();
            }

            if (panelStack.Count <= 0)
            {
                return;
            }

            //退出栈顶界面
            UIBase topPanel = panelStack.Pop();
            topPanel.OnExit();

            //恢复上一界面
            if (panelStack.Count > 0)
            {
                UIBase panel = panelStack.Peek();
                panel.OnResume();
            }
        }

        //获取最上层界面
        public UIBase GetTopBase()
        {
            return panelStack.Count > 0 ? panelStack.Peek() : null;
        }
    }
}
