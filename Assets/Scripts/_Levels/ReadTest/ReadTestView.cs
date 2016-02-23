using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;
using Assets.Scripts.Sound;
using System;
using System.Collections.Generic;

namespace Assets.Scripts._Levels.ReadTest
{

	public class ReadTestView : LevelView
    {
        public Text readingText,questionText;
		public Toggle[] answerButtons;
		public ToggleGroup toggleGroup;
		public Button submitButton;


		//las rtas son toggles, el boton hace el subt

		internal void NextChallenge(Question question)
        {
			readingText.text = question.Paragraph;
			questionText.text = question.QuestionText;
			for (int i = 0; i < 3; i++) {
				answerButtons [i].GetComponentInChildren<Text>().text = question.AnswersTexts [i];
			}

            
        }

		void ShuffleAnswers(string[] answerTexts){
			
		}

        public void OnClickSubmit()
        {
			IEnumerator<Toggle> toggleEnum = toggleGroup.ActiveToggles().GetEnumerator();
			toggleEnum.MoveNext();
			Toggle toggle = toggleEnum.Current;
            PlaySoundClick();
			ReadTestController.GetController().CheckAnswer(toggle.GetComponentInChildren<Text>().text);
        }

        public void OnClickSecondtButton(string answer)
        {
            PlaySoundClick();
            ReadTestController.GetController().CheckAnswer(answer);
        }

        internal void CorrectAnswer()
        {
            PlayRightSound();
        }

        internal void WrongAnswer()
        {
            PlayWrongSound();
        }

        public override void RestartGame()
        {
//            answer.text = "";
        }


    }
}