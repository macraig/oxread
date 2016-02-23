using SimpleJSON;
using UnityEngine;
using Assets.Scripts;
using System.Collections.Generic;

namespace Assets.Scripts._Levels.ReadTest
{

	public class ReadTestModel : LevelModel
    {
		private static Random rng = new Random();  

		private int questionCounter,correctAnswers,incorrectAnswers,hints;
		private string currentAnswer;
		private List<Question> questions;
		private Question currentQuestion;



		public ReadTestModel(int level){
			questionCounter = -1;
			correctAnswers = 0;
			incorrectAnswers = 0;
			hints = 0;
			questions = new List<Question> ();
			LoadExercises (level);

		}

		void LoadExercises(int level){
			string exerciseFileName = "LecturaComprensiva"+(level+1).ToString();

			TextAsset JSONstring = Resources.Load(exerciseFileName) as TextAsset;
			JSONNode data = JSON.Parse(JSONstring.text);

			int totalExercises = data ["exercises"].Count;
			string paragraphText, questionText;
			string[] hintTexts,answerTexts;
			int questionType;


			for (int i = 0; i < totalExercises; i++) {
				
				paragraphText = data ["exercises"][i]["paragraph"];
				questionText = data ["exercises"][i]["questions"][0];

				hintTexts = GetStringArray(data ["exercises"][i]["hints"].AsArray);
				answerTexts = GetStringArray(data ["exercises"][i]["answers"].AsArray);
				questionType = data ["exercises"][i]["questionType"].AsInt;

				Question question = new Question (paragraphText, questionText, hintTexts, answerTexts, questionType,i);

				questions.Add (question);
//				Debug.Log (question.Paragraph+question.QuestionText);
			}


		}

		string[] GetStringArray(JSONArray jsonArray){
			
			string[] array = new string[jsonArray.Count];
			for (int i = 0; i <jsonArray.Count ; i++) {
				array [i] = jsonArray [i];
			}
			return array;
		}


		public override void NextChallenge()
        {
			questionCounter++;
			if (questionCounter < questions.Count) {
				currentQuestion = questions [Random.Range (0, questions.Count)];
				currentAnswer = currentQuestion.AnswersTexts[0];
				Shuffle (currentQuestion.AnswersTexts);
			}
        }

        public override void RestartGame()
        {
            currentAnswer = "";
        }

        public override void StartGame()
        {
            currentAnswer = "";

			questionCounter = 0;
			correctAnswers=0;
			incorrectAnswers=0;
			hints=0;
        }

        internal bool CheckAnswer(string answer)
        {
			return currentAnswer.Equals(answer);
        }

        internal string GetCurrentAnswer()
        {
            return currentAnswer;
        }

		public Question CurrentQuestion {
			get {
				return currentQuestion;
			}
		}


		static void Shuffle<T>(T[] array)
		{	
			int n = array.Length;
			for (int i = 0; i < n; i++)
			{
				int r = i + (int)(Random.value * (n - i));
				T t = array[r];
				array[r] = array[i];
				array[i] = t;
			}
		}
    }
}
