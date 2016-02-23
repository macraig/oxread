using UnityEngine;
using Assets.Scripts.Sound;
using Assets.Scripts.App;

namespace Assets.Scripts.Instructions
{
    public class GameRules : MonoBehaviour
    {


        void Start(){
        }

    

        public void OnClickBackToGame()
        {
            ClickSound();
            ViewController.GetController().HideInstructions();
        }

        private void ClickSound()
        {
            SoundController.GetController().PlayClickSound();
        }
    }
}