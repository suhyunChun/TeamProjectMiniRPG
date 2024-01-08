using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace Managers
{
    public class UIManager
    {
        #region Field
        private int _orderByLayer = 1;
        private Stack<PopupUI> _popupStack = new();
        public BaseUI SceneUI { get; private set; }

        private GameObject UIBase
        {
            get
            {
                GameObject uiBase = GameObject.Find("@UI_Base");
                if (uiBase == null)
                {
                    uiBase = new GameObject { name = "@UI_Base" };
                }
                return uiBase;
            }
        }
        #endregion


        #region SetUI
        public T SetSceneUI<T>() where T : BaseUI
        {
            string sceneUIName = typeof(T).Name;
            SceneUI = SetUI<T>(sceneUIName, UIBase.transform);
            return (T)SceneUI;
        }

        private T SetUI<T>(string uiName, Transform parent = null) where T : Component
        {
            GameObject uiObject = Main.Resource.InstantiatePrefab(uiName, parent);
            T ui = Utility.GetAddComponent<T>(uiObject);
            return ui;
        }
        #endregion


        #region Popup
        private string NameOfUI<T>(string uiName)
        {
            return string.IsNullOrEmpty(uiName) ? typeof(T).Name : uiName;
        }

        public T OpenPopup<T>() where T : PopupUI
        {
            string uiName = typeof(T).Name;
            string ui = NameOfUI<T>(uiName);
            T popup = SetUI<T>(ui, UIBase.transform);
            popup.name = $"{uiName}";
            _popupStack.Push(popup);
            //Open?.Invoke();
            return popup;
        }


        public void ClosePopup(PopupUI popup, List<UI_EVENT_TYPE> eventTypes)
        {
            _popupStack.Pop();
            UnbindPopupEvents(popup, eventTypes);
            _orderByLayer--;
            Object.Destroy(popup.gameObject);
        }

        private void UnbindPopupEvents(PopupUI popup, List<UI_EVENT_TYPE> eventTypes)
        {
            UIEventHandler[] eventsHandler = popup.GetComponents<UIEventHandler>();
            foreach (UIEventHandler handler in eventsHandler)
            {
                foreach (UI_EVENT_TYPE eventType in eventTypes)
                {
                    handler.UnbindEvent(eventType);
                }
            }
        }
        #endregion

        #region SubItem

        public T SetSubItemUI<T>(Transform parent = null) where T : BaseUI
        {
            string subitemUIName = typeof(T).Name;
            return SetUI<T>(subitemUIName, parent);
        }

        public void DestroySubItemUI<T>(GameObject gameob) where T : BaseUI
        {
            string subitemUIName = typeof(T).Name;
            Object.Destroy(gameob);
        }
        #endregion


        #region Canvas Layer
        public void OrderLayerToCanvas(GameObject uiObject, bool sort = true)
        {
            Canvas canvas = Utility.GetAddComponent<Canvas>(uiObject);
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.overrideSorting = true;
            SortingOrder(canvas, sort);
            CanvasScaler scales = Utility.GetAddComponent<CanvasScaler>(canvas.gameObject);
            scales.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scales.referenceResolution = new Vector2(1920, 1080);
            canvas.referencePixelsPerUnit = 100;
        }

        private void SortingOrder(Canvas canvas, bool sort)
        {
            canvas.sortingOrder = sort ? _orderByLayer++ : 0;
        }

        #endregion

    }
}