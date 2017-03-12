using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Assets.Scripts.App;
using System;

namespace Assets.Scripts.Metrics
{

    public class MetricsController : MonoBehaviour
    {

        private static MetricsController metricsController;
        private MetricsModel metricsModel;
        private CsvReadWriter csvReadWriter;
        //Awake is always called before any Start functions
        void Awake()
        {
            if (metricsController == null)
                metricsController = this;
            else if (metricsController != this)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
            csvReadWriter = new CsvReadWriter();
        }

        private void SaveToDisk()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/" + (AppController.GetController().GetCurrentChallenge()+1) + "levelComprehension.dat");
            bf.Serialize(file, metricsModel);
            file.Close();

            csvReadWriter.AddRow(metricsModel.GetCurrentTest());

        }

        public void LoadFromDisk(string username)
        {
            if (File.Exists(Application.persistentDataPath + "/" + (AppController.GetController().GetCurrentChallenge() + 1) + "levelComprehension.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/" + (AppController.GetController().GetCurrentChallenge() + 1) + "levelComprehension.dat", FileMode.Open);
                metricsModel = (MetricsModel)bf.Deserialize(file);
                file.Close();
            }
            else
            {
                metricsModel = new MetricsModel();
            }
            csvReadWriter.CreateNewCSV(AppController.GetController().GetCurrentChallenge());
            NewTest(username);

        }

        public void NewTest(string username)
        {
            metricsModel.NewTest(username);
        }

        public TestResult GetCurrentTest()
        {
            return metricsModel.GetCurrentTest();
        }

        public static MetricsController GetController()
        {
            return metricsController;
        }

        internal void GameEnd()
        {
            SaveToDisk();
        }

        internal CsvReadWriter GetCsvReaderWriter()
        {
            return csvReadWriter;
        }
    }



}
