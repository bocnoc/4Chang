using System;
using System.Collections.Generic;
using Model;
using UnityEngine;
namespace Presenter
{
    public class FlirtingScenePresenter : MonoBehaviour
    {
        private void Awake()
        {
            UpdateUseQuote();
        }
        private void UpdateUseQuote()
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


        public string GetTodayMessage(DateTime todayTime)
        {
            bool todayToken = gotMessageToday(todayTime);
            if (todayToken)
            {
                return "Một ngày một câu thôi e ơi";
            }
            
            
            //var todayMessage = FlirtingDatabase.flirtingList[UnityEngine.Random.Range(0, FlirtingDatabase.flirtingList.Count)];
            var todayMessage = GetUnusedMessage();
            return todayMessage;
        }
        private string GetUnusedMessage()
        {
            throw new NotImplementedException();
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
