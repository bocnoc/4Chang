using System;
using System.Linq;
using Presenter;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
namespace Views
{
    public class FlirtSceneView : MonoBehaviour
    {
        private Button randomButton;
        private Button closeButton;

        private TextMeshProUGUI messageText;
        private RectTransform doneNotice;
        private RectTransform subMessage;
        private DateTime lastRandomTime;

        private FlirtingScenePresenter flirtingScenePresenter; 
        private void Awake()
        {
            flirtingScenePresenter = GetComponentInChildren<FlirtingScenePresenter>();
            
            randomButton = gameObject.GetComponentsInChildren<Button>(true).First(name => name.name.Contains("Random"));
            closeButton = gameObject.GetComponentsInChildren<Button>(true).First(name => name.name.Contains("Close"));
            messageText = gameObject.GetComponentsInChildren<TextMeshProUGUI>(true).First(name => name.name.Contains("FlirtMessageText"));
            doneNotice = gameObject.GetComponentsInChildren<RectTransform>(true).First(name => name.name.Contains("WrongAnswer"));
            subMessage = gameObject.GetComponentsInChildren<RectTransform>(true).First(name => name.name.Contains("RightAnswer"));
        }

        private void Start()
        {
            randomButton.onClick.AsObservable().Subscribe(_ =>
            {
                var todayTime = DateTime.Now;
                var todayMessage = flirtingScenePresenter.GetTodayMessage(todayTime);
                ShowMessageOfTheDay(todayMessage);
            }).AddTo(this);
        }
        private void ShowMessageOfTheDay(string message)
        {
            messageText.text = message;
        }
    }
}
