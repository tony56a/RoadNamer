﻿using ColossalFramework.UI;
using RoadNamer.CustomUI;
using RoadNamer.Managers;
using RoadNamer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RoadNamer.Panels
{
    public class UsedNamesPanel : UIPanel,IEventSubscriber
    {
        protected RectOffset m_UIPadding = new RectOffset(5, 5, 5, 5);

        private int titleOffset = 40;
        private UITitleBar m_panelTitle;
        public UIFastList usedNamesList = null;

        private Vector2 offset = Vector2.zero;

        public override void Awake()
        {
            this.isInteractive = true;
            this.enabled = true;
            this.width = 350;
            this.height = 300;

            base.Awake();
        }

        public override void Start()
        {
            base.Start();

            m_panelTitle = this.AddUIComponent<UITitleBar>();
            m_panelTitle.title = "Existing names";
            m_panelTitle.iconAtlas = SpriteUtilities.GetAtlas("RoadNamerIcons");
            m_panelTitle.iconSprite = "ToolbarFGIcon";
            m_panelTitle.m_closeActions.Add("closeAll");

            CreatePanelComponents();

            this.relativePosition = new Vector3(Mathf.Floor((GetUIView().fixedWidth - width) / 2) + width, Mathf.Floor((GetUIView().fixedHeight - height) / 2 ) - height - m_UIPadding.top);
            this.backgroundSprite = "MenuPanel2";
            this.atlas = CustomUI.UIUtils.GetAtlas("Ingame");
        }

        private void CreatePanelComponents()
        {
            usedNamesList = UIFastList.Create<UIUsedNameRowItem>(this);
            usedNamesList.backgroundSprite = "UnlockingPanel";
            usedNamesList.size = new Vector2(this.width-m_UIPadding.left-m_UIPadding.right, (this.height-titleOffset- m_UIPadding.top-m_UIPadding.bottom));
            usedNamesList.canSelect = false;
            usedNamesList.relativePosition = new Vector2(m_UIPadding.left, titleOffset + m_UIPadding.top);
            usedNamesList.rowHeight = 40f;
            usedNamesList.rowsData.Clear();
            usedNamesList.selectedIndex = -1;

            RefreshList();
        }

        public void RefreshList()
        {
            usedNamesList.rowsData.Clear();
            foreach (string usedName in RoadNameManager.Instance().m_usedNames.Keys)
            {
                usedNamesList.rowsData.Add(usedName);
            }
            usedNamesList.DisplayAt(0);
            usedNamesList.selectedIndex = 0;
        }

        public void onReceiveEvent(string eventName, object eventData)
        {
            string message = eventData as string;
            switch (eventName)
            {
                case "forceupdateroadnames":
                    RefreshList();
                    break;
                case "closeUsedNamePanel":
                    Hide();
                    break;
                case "closeAll":
                    Hide();
                    break;
                default:
                    break;
            }
        }
    }

    public class UsedRoutesPanel : UIPanel, IEventSubscriber
    {
        protected RectOffset m_UIPadding = new RectOffset(5, 5, 5, 5);

        private int titleOffset = 40;
        private UITitleBar m_panelTitle;
        public UIFastList usedRoutesList = null;

        private Vector2 offset = Vector2.zero;

        public override void Awake()
        {
            this.isInteractive = true;
            this.enabled = true;
            this.width = 350;
            this.height = 300;

            base.Awake();
        }

        public override void Start()
        {
            base.Start();

            m_panelTitle = this.AddUIComponent<UITitleBar>();
            m_panelTitle.title = "Existing routes";
            m_panelTitle.iconAtlas = SpriteUtilities.GetAtlas("RoadNamerIcons");
            m_panelTitle.iconSprite = "ToolbarFGIcon";
            m_panelTitle.m_closeActions.Add("closeAll");

            CreatePanelComponents();

            this.relativePosition = new Vector3(Mathf.Floor((GetUIView().fixedWidth - width) / 2) + width, Mathf.Floor((GetUIView().fixedHeight - height) / 2));
            this.backgroundSprite = "MenuPanel2";
            this.atlas = CustomUI.UIUtils.GetAtlas("Ingame");
        }

        private void CreatePanelComponents()
        {
            
            usedRoutesList = UIFastList.Create<UIUsedRouteRowItem>(this);
            usedRoutesList.backgroundSprite = "UnlockingPanel";
            usedRoutesList.size = new Vector2(this.width - m_UIPadding.left - m_UIPadding.right, (this.height - titleOffset - m_UIPadding.top - m_UIPadding.bottom));
            usedRoutesList.canSelect = false;
            usedRoutesList.relativePosition = new Vector2(m_UIPadding.left, titleOffset + m_UIPadding.top );
            usedRoutesList.rowHeight = 40f;
            usedRoutesList.rowsData.Clear();
            usedRoutesList.selectedIndex = -1;

            RefreshList();
        }

        public void RefreshList()
        {
        
            usedRoutesList.rowsData.Clear();
            foreach (string route in RoadNameManager.Instance().m_usedRoutes.Keys)
            {
                usedRoutesList.rowsData.Add(route);
            }
            usedRoutesList.DisplayAt(0);
            usedRoutesList.selectedIndex = 0;
        }

        public void onReceiveEvent(string eventName, object eventData)
        {
            string message = eventData as string;
            switch (eventName)
            {
                case "forceupdateroadnames":
                    RefreshList();
                    break;
                case "closeUsedNamePanel":
                    Hide();
                    break;
                case "closeAll":
                    Hide();
                    break;
                default:
                    break;
            }
        }
    }
}
