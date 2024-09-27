using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SideMenuView : MonoBehaviour
{
    private Button[] menu;
    private Subject<int> currentTabIndex = new Subject<int>();
    public IObservable<int> onClickSideMenuAsObservable() => currentTabIndex;
    void Awake()
    {
        menu = GetComponentsInChildren<Button>(true).Where(x => x.name.Contains("Menu")).ToArray();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var (sideButton, buttonIndex) in menu.Select((button, buttonIndex) => (button, buttonIndex)))
        {
            sideButton.onClick.AsObservable().Subscribe(_ =>
            {
                currentTabIndex.OnNext(buttonIndex);
            }).AddTo(this);
        }
        
    }

    public void ChangeTab(int tabIndex)
    {
        switch (tabIndex)
        {
            case 0:
                SceneManager.LoadScene("Mainscene");
                break;
            case 1:
                SceneManager.LoadScene("FlirtingScene");
                break;
            case 2:                
                SceneManager.LoadScene("Mainscene");
                break;
            case 3:
                SceneManager.LoadScene("Mainscene");
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
