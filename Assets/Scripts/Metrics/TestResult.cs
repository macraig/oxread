using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.App;
using System;

namespace Assets.Scripts.Metrics
{
    [Serializable]

    public class TestResult 
    {
        private string username;
        private string date;
        private float score;
        private GameMetrics gameResults;

        public TestResult(string username, int games)
        {
            this.username = username;
            date = System.DateTime.Now.Day + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Year;
            gameResults = new GameMetrics();
        }

        internal void LogRightAnswer(int activity)
        {
            gameResults.AddRightAnswer(activity);
        }
        internal void LogWrongAnswer(int activity)
        {
            gameResults.AddWrongAnswer(activity);
        }
        internal void LogHint(int activity)
        {
            gameResults.AddHint(activity);
        }

        internal GameMetrics GetGameResults()
        {
            return gameResults;
        }

        internal string GetUsername()
        {
            return username;
        }

        internal string GetDate()
        {
            return date;
        }
    }
}