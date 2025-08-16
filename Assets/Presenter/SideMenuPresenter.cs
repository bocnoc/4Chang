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
            HandleSceneTransition(tabIndex);
        }).AddTo(this);

        sideMenuView.onClickSideMenuAsObservable().Subscribe(tabIndex =>
        {
            SideMenuModel.Instance.CurrentSelectTab.Value = tabIndex;
        }).AddTo(this);
    }

    private void HandleSceneTransition(int tabIndex)
    {
        switch (tabIndex)
        {
            case 0:
                PlatformSceneManager.LoadMainScene();
                break;
            case 1:
                PlatformSceneManager.LoadFlirtingScene();
                break;
            case 2:
                PlatformSceneManager.LoadCountingScene();
                break;
            case 3:
                PlatformSceneManager.LoadMainScene();
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
