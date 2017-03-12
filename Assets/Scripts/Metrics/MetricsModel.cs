using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.App;
using System;

namespace Assets.Scripts.Metrics
{
    [Serializable]
    public class MetricsModel
    {

        private List<TestResult> tests;

        public MetricsModel()
        {
            tests = new List<TestResult>();
        }

        internal void NewTest(string username)
        {
            tests.Add(new TestResult(username, AppController.GetController().GetGamesQuantity()));
        }

        internal TestResult GetCurrentTest()
        {
            return tests[tests.Count - 1];
        }

        internal List<TestResult> GetTests()
        {
            return tests;
        }
    }

}