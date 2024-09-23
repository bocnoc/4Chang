using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class SidePresenterView : MonoBehaviour
{
    private Button menu1;
    private Button menu2;
    private Button menu3;
    private Button menu4;
    
    void Awake()
    {
        menu1 = GetComponentsInChildren<Button>(true).FirstOrDefault(x => x.name.Equals("BorderMenu1"));
        menu2 = GetComponentsInChildren<Button>(true).FirstOrDefault(x => x.name.Equals("BorderMenu2"));
        menu3 = GetComponentsInChildren<Button>(true).FirstOrDefault(x => x.name.Equals("BorderMenu3"));
        menu4 = GetComponentsInChildren<Button>(true).FirstOrDefault(x => x.name.Equals("BorderMenu4"));
    }

    // Start is called before the first frame update
    void Start()
    {
        menu1.OnClickAsObservable().Subscribe(_ => {
        }).AddTo(this);
        menu2.OnClickAsObservable().Subscribe(_ => {
        }).AddTo(this);
        menu3.OnClickAsObservable().Subscribe(_ => {
        }).AddTo(this);
        menu4.OnClickAsObservable().Subscribe(_ => {
        }).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
