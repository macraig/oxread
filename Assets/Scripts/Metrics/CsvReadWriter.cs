using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.App;
using System.Text;
using Assets.Scripts._Levels.ReadTest;

namespace Assets.Scripts.Metrics
{

    public class CsvReadWriter
    {

        private static CsvReadWriter csvReadWriter;

        private string CSVString;
        private string path;
        private int level;



        public void CreateNewCSV(int level)
        {
            this.level = level;
            path = Application.persistentDataPath + "/Level" + (level + 1) + ".csv";
            if (File.Exists(path))
            {
                CSVString = File.ReadAllText(path);
            }
            else {

                // Creating First row of titles
                List<string> rowDataTemp = new List<string>();
                rowDataTemp.Add("Username");
                rowDataTemp.Add("Date");
                rowDataTemp.Add("Global Correct Answers");
                rowDataTemp.Add("Global Wrong Answers");
                rowDataTemp.Add("Global Hints");
                for (int i = 0; i < ReadTestController.GetController().GetTotalActivities(); i++)
                {
                    string activity = ReadTestController.GetController().GetActivityName(i);
                    rowDataTemp.Add("Pregunta " + (i+1) +  " Correct");
                    rowDataTemp.Add("Pregunta " + (i + 1) + " Hints");
                }                         
       

                //int questionsCells = questions.Count;
                //for (int i = 0; i < questionsCells; i++)
                //{
                //    rowDataTemp.Add(questions[i].QuestionText);
                //    rowDataTemp.Add("Hint");
                //}

                Save(level, path, rowDataTemp);

            }

        }

        // tring username, string date, int globalCorrect, int globalWrong, int globalHints,
        //int[] typeCorrect, int[] typeWrong, int[] typeHints

        public void AddRow(TestResult test)
        {

            List<string> rowDataTemp = new List<string>();
            rowDataTemp.Add(test.GetUsername());
            rowDataTemp.Add(test.GetDate());
            int globalCorrect = 0;
            int globalWrong = 0;
            int globalHints = 0;

            for (int i = 0; i < test.GetGameResults().GetAnswers().Length; i++)
            {
                globalCorrect += test.GetGameResults().GetAnswers()[i] == 1 ? 1 : 0;
                globalWrong += test.GetGameResults().GetAnswers()[i] == 0 ? 1 : 0;
                globalHints += test.GetGameResults().GetHints()[i] == 1 ? 1 : 0;
            }
            rowDataTemp.Add(""+globalCorrect);
            rowDataTemp.Add(""+globalWrong);
            rowDataTemp.Add(""+ globalHints);
            for (int i = 0; i < ReadTestController.GetController().GetTotalActivities(); i++)
            {
                rowDataTemp.Add("" + test.GetGameResults().GetAnswers()[i]);
                rowDataTemp.Add("" + test.GetGameResults().GetHints()[i]);
            }
            Save(level, path, rowDataTemp);
        }

        public void Save(int level, string path, List<string> rowData)
        {

            int length = rowData.Count;

            StringBuilder sb = new StringBuilder();


            string tempString = "";
            for (int i = 0; i < rowData.Count; i++)
            {
                tempString += rowData[i];
                tempString += ",";
            }
            sb.AppendLine(tempString.Substring(0, tempString.Length - 1));
            //      StreamWriter outStream = System.IO.File.CreateText(path);
            StreamWriter outStream = File.AppendText(path);
            outStream.Write(sb);
            //outStream.WriteLine(sb);

            outStream.Close();
            Debug.Log("Created " + path);
        }
    }

}