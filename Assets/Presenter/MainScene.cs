using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    private Button showLoveButton;
    private Button hideLoveButton;
    private RectTransform loveMessage;

    void Awake()
    {
        showLoveButton =  gameObject.GetComponentsInChildren<Button>(true).First(x => x.name.Contains("Show"));
        hideLoveButton =  gameObject.GetComponentsInChildren<Button>(true).First(x => x.name.Contains("Hide"));
        loveMessage = gameObject.GetComponentsInChildren<RectTransform>(true).First(n => n.name.Contains("BorderHelloMessage"));
    }

    // Start is called before the first frame update
    void Start()
    {
        showLoveButton.OnClickAsObservable().Subscribe(_ =>
        {
            loveMessage.gameObject.SetActive(true);
        }).AddTo(this);

        hideLoveButton.OnClickAsObservable().Subscribe(_ =>
        {
            loveMessage.gameObject.SetActive(false);
        }).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
