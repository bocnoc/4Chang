using System;
using System.Linq;
using Presenter;
using TMPro;
using UniRx;
using Unity.VisualScripting;
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
        private RectTransform getQuoteOverlay;
        [SerializeField]
        private GameObject cell;
        [SerializeField]
        private Transform newQuote;
        [SerializeField]
        private Transform oldQuote;

        private FlirtingScenePresenter flirtingScenePresenter; 
        private void Awake()
        {
            flirtingScenePresenter = GetComponentInChildren<FlirtingScenePresenter>();
            
            randomButton = gameObject.GetComponentsInChildren<Button>(true).First(name => name.name.Contains("Random"));
            closeButton = gameObject.GetComponentsInChildren<Button>(true).First(name => name.name.Contains("Close"));
            messageText = gameObject.GetComponentsInChildren<TextMeshProUGUI>(true).First(name => name.name.Contains("FlirtMessageText"));
            doneNotice = gameObject.GetComponentsInChildren<RectTransform>(true).First(name => name.name.Contains("WrongAnswer"));
            subMessage = gameObject.GetComponentsInChildren<RectTransform>(true).First(name => name.name.Contains("RightAnswer"));
            getQuoteOverlay = gameObject.GetComponentsInChildren<RectTransform>(true).First(name => name.name.Contains("RandomFlirtMessage"));
        }

        private void Start()
        {
            randomButton.onClick.AsObservable().Subscribe(_ =>
            {
                var todayTime = DateTime.Today;
                var todayMessage = flirtingScenePresenter.GetTodayMessage(todayTime);
                ShowMessageOfTheDay(todayMessage);
            }).AddTo(this);

            closeButton.onClick.AsObservable().Subscribe(_ =>
            {
                getQuoteOverlay.gameObject.SetActive(false);
            }).AddTo(this);
        }
        private void ShowMessageOfTheDay(string message)
        {
            messageText.text = message;
        }
        
        public void AddNewQuoteButton(string name, string code)
        {
            var newCell = Instantiate(cell, newQuote);
            newCell.GameObject().SetActive(true);
            
            newCell.GetComponent<Button>().OnClickAsObservable().Subscribe(_ =>
            {
                Debug.Log(code);
                //onConfirmBySelect.OnNext(code);
            }).AddTo(this);
            newCell.GetComponentsInChildren<TextMeshProUGUI>().First(x => x.name.Contains("textContent")).text = name;
        }
        public void AddOldQuoteButton(string name, string code)
        {
            var newCell = Instantiate(cell, oldQuote);
            newCell.GameObject().SetActive(true);
            
            newCell.GetComponent<Button>().OnClickAsObservable().Subscribe(_ =>
            {
                Debug.Log(code);
                //onConfirmBySelect.OnNext(code);
            }).AddTo(this);
            newCell.GetComponentsInChildren<TextMeshProUGUI>().First(x => x.name.Contains("textContent")).text = name;
        }
    }
}
