using UnityEngine;
namespace AppSystemManager
{
    public static class InitializingApplicationController
    {
        //アプリケーション起動直前に呼び出され、初期化を行う。
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnApplicationStart()
        {
            var obj = new GameObject("InitAppComponent");
            obj.AddComponent<SingletonInstanceMaker>();
            
            
        }
    }
}