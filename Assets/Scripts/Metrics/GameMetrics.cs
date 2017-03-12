using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts._Levels.ReadTest;


namespace Assets.Scripts.Metrics
{
    [Serializable]
    public class GameMetrics
    {
        private int[] hints;
        private int[] answers;

        public GameMetrics()
        {
            int totalActivities = ReadTestController.GetController().GetTotalActivities();
            answers = new int[totalActivities];
            hints = new int[totalActivities];
        }

        internal void AddRightAnswer(int question)
        {
            answers[question] = 1;
        }

        internal void AddWrongAnswer(int question)
        {
            answers[question] = 0;
        }

        internal void AddHint(int question)
        {
            hints[question] = 1;
        }

        internal int[] GetAnswers()
        {         
            return answers;
        }
   
        internal int[] GetHints()
        {
            return hints;
        }
    }
}