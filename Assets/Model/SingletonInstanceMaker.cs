using System;
using UnityEngine;

public class SingletonInstanceMaker: MonoBehaviour
{
    private void Awake()
    {
        //DontDestroyOnLoadでシーンが切り替わっても消えないようにし、アプリ終了時の挙動を保証する。
        //実質MonoBehaviour Singleton なので、初期化以外でManagerを作りたい場合ははSingleton化したほうがよいかも？
        DontDestroyOnLoad(gameObject);
    }
    
}
