using Managers;
using UI.Scene;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Scene
{
    public class BaseScene : MonoBehaviour
    {
        private bool _initialize;
        protected UIManager UI;
        private void Start()
        {
            /*
            Debug.Log("base scene");
            Main.Resource.AllLoadResource<Object>("Preload", (key, count, totalCount) =>
            {
                Debug.Log(count);
                if (count <totalCount) return;
                Initialized();
            });
            */


            if (Main.Resource.LoadBase) Initialized();
            else
            {
                Main.Resource.AllLoadResource<Object>("Preload", (key, count, totalCount) =>
                {
                    Debug.Log($"[BaseScene] Load asset {key} ({count}/{totalCount})");
                    if (count < totalCount) return;
                    Main.Resource.LoadBase = true;
                    Initialized();
                });
            }

        }


        protected virtual bool Initialized()
        {

            if (_initialize) return false;
            _initialize = true;
            UI = Main.UI;
            Main.Scenes.CurrentSceneObject = this.gameObject;
            return _initialize;
        }
    }

    /*
     private void Awake()
        {
            if (Main.Resource.LoadBase) Initialized();
            else
            {
                Main.Resource.AllLoadAsync<Object>("Preload", (key, count, totalCount) =>
                {
                    Debug.Log($"[BaseScene] Load asset {key} ({count}/{totalCount})");
                    if (count < totalCount) return;
                    Main.Resource.LoadBase = true;
                    Initialized();
                });
            }
        }*/
}