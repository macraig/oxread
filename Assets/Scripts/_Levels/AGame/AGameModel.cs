using UnityEngine;

namespace Assets.Scripts._Levels.AGame
{

    public class AGameModel : LevelModel
    {
        private int currentAnswer;

        public override void NextChallenge()
        {
            currentAnswer = Random.Range(1, 3);
        }

        public override void RestartGame()
        {
            currentAnswer = -1;
        }

        public override void StartGame()
        {
            minSeconds = 15;
            pointsPerError = 200;
            pointsPerSecond = 13;
            currentAnswer = -1;
        }

        internal bool CheckAnswer(int answer)
        {
            return currentAnswer == answer;
        }

        internal int GetCurrentAnswer()
        {
            return currentAnswer;
        }
    }
}
