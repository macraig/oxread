using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;
using Assets.Scripts.Sound;
using System;

namespace Assets.Scripts._Levels.AGame
{

    public class AGameView : LevelView
    {
        public Text answer;         

        internal void NextChallenge(int answer)
        {
            try
            {
                this.answer.text = "" + answer;
            }
            catch (MissingReferenceException)
            {
                this.answer = GameObject.Find("questionText").GetComponent<Text>();
                this.answer.text = "" + answer;
            }
            
        }

        public void OnClickFirstButton(int answer)
        {
            PlaySoundClick();
            AGameController.GetController().CheckAnswer(answer);
        }

        public void OnClickSecondtButton(int answer)
        {
            PlaySoundClick();
            AGameController.GetController().CheckAnswer(answer);
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
            answer.text = "";
        }
    }
}