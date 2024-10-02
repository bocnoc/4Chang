using System;
using System.Collections.Generic;
using Model;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

public class FlirtingSceneModel
{
    private static FlirtingSceneModel _instance;
    public ReactiveProperty<List<string>> usedQuote;

    public static FlirtingSceneModel Instance
    {
        get => _instance ?? throw new ArgumentNullException();
        set
        {
            Assert.IsNull(_instance, "You are not allowed to assign to a generated instance");
            _instance = value;
        }
    }
}
