using System;
using UniRx;
using UnityEngine;

public class CountingScenePresenter : MonoBehaviour
{
    CountingSceneView countingSceneView;
    DateTime acceptDating = new DateTime(2023, 10, 5, 21, 9, 0);
    private void Awake()
    {
       countingSceneView = GetComponent<CountingSceneView>();
    }

    private void Update()
    {
        var rightnowDate = DateTime.Now;
        CountingSceneModel.Instance.datingTime.Value = rightnowDate.Subtract(acceptDating);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CountingSceneModel.Instance.datingTime.Subscribe(t =>
        {
            countingSceneView.ChangeDateingTime(t);
            Debug.Log(CountingSceneModel.Instance.datingTime.Value);
        }).AddTo(this);
    }

}
