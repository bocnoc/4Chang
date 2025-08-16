using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

public class CountingSceneModel : MonoBehaviour
{
    private static CountingSceneModel _instance;
    public ReactiveProperty<TimeSpan> datingTime = new ReactiveProperty<TimeSpan>();

    public static CountingSceneModel Instance
    {
        get => _instance ?? throw new ArgumentNullException();
        set
        {
            Assert.IsNull(_instance, "You are not allowed to assign to a generated instance");
            _instance = value;
        }
    }
}
