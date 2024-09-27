using System;
using System.Collections;
using System.Collections.Generic;
using Model;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SideMenuPresenter : MonoBehaviour
{
    private SideMenuView sideMenuView;
    
    private void Awake()
    {
        sideMenuView = gameObject.GetComponentInChildren<SideMenuView>(true);
    }
    void Start()
    {
        SideMenuModel.Instance.CurrentSelectTab.SkipLatestValueOnSubscribe().Subscribe(tabIndex =>
        {
            sideMenuView.ChangeTab(tabIndex);
        }).AddTo(this);

        sideMenuView.onClickSideMenuAsObservable().Subscribe(tabIndex =>
        {
            SideMenuModel.Instance.CurrentSelectTab.Value = tabIndex;
        }).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
