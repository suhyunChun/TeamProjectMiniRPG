using UI.Scene;
using UnityEngine;

namespace Scene
{
    public class IntroScene : BaseScene
    {
        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;
            Main.Resource.AllLoadResource<Object>("Intro", (key, loadCount, totalCount) => { 
                if(loadCount == totalCount) 
                {
                    UI.SetSceneUI<TestUI>();
                }
            });
            
            return true;
        }
    }
}