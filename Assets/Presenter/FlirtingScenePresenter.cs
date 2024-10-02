using System;
using System.Collections.Generic;
using Model;
using UniRx;
using UnityEngine;
namespace Presenter
{
    public class FlirtingScenePresenter : MonoBehaviour
    {
        private void Awake()
        {
            UpdateUsedQuote();
        }

        private void Start()
        {
        }
        private void UpdateUsedQuote()
        {
            List<string> tmpList = new List<string>();
            for (int i = 0; i < FlirtingDatabase.flirtingList.Count; i++)
            {
                if (PlayerPrefs.GetInt("Quote_" + i.ToString(), 0) != 0)
                {
                    tmpList.Add(FlirtingDatabase.flirtingList[i]);
                }
            }
            FlirtingSceneModel.Instance.usedQuote.Value = tmpList;
        }

/// <summary>
/// return a random message if today didn't open yet
/// </summary>
/// <param name="todayTime"></param>
/// <returns> todayMessage="random from list"</returns>
        public string GetTodayMessage(DateTime todayTime)
        {
            bool todayToken = gotMessageToday(todayTime);
            if (todayToken)
            {
                return "Mỗi ngày một câu thôi e ơi";
            }
            
            
            //var todayMessage = FlirtingDatabase.flirtingList[UnityEngine.Random.Range(0, FlirtingDatabase.flirtingList.Count)];
            var todayMessage = GetUnusedMessage();
            saveUsedMessage(todayMessage);
            return todayMessage;
        }
        private void saveUsedMessage(string todayMessage)
        {
            for (int i = 0; i < FlirtingDatabase.flirtingList.Count; i++)
            {
                if (FlirtingDatabase.flirtingList[i] == todayMessage)
                {
                    FlirtingSceneModel.Instance.usedQuote.Value.Add(todayMessage);
                    PlayerPrefs.SetInt("Quote_" + i.ToString(), 1);
                    PlayerPrefs.Save();
                }
            }
        }
        private string GetUnusedMessage()
        {
            for (int i = 0; i < FlirtingDatabase.flirtingList.Count; i++)
            {
                if (!FlirtingSceneModel.Instance.usedQuote.Value.Contains(FlirtingDatabase.flirtingList[i]))
                {
                    return FlirtingDatabase.flirtingList[i];
                }
            }
            return "Hết văn rồi em ơi";
        }
        
        private bool gotMessageToday(DateTime todayTime)
        {
            var gotQuote = PlayerPrefs.GetInt(todayTime.ToString(), 0);
            if (gotQuote == 0)
            {
                PlayerPrefs.SetInt(todayTime.ToString(), 1);
                PlayerPrefs.Save();
                return false;
            }
            else
            {
                return true;
            }
        }
        
    }
}
