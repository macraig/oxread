using Assets.Scripts.App;
using UnityEngine;
namespace Assets.Scripts._Levels.ReadTest
{

	public class ReadTestController : LevelController
    {
		private static ReadTestController readTestController;
		public ReadTestView readTestView;

		private ReadTestModel readTestModel;
        private const int TO_END = 5;

        void Awake()
        {
            if (readTestController == null) readTestController = this;
            else if (readTestController != this) Destroy(this);
            InitGame();
        }

        public override void InitGame()
        {
			readTestModel = new ReadTestModel(AppController.GetController().GetCurrentGame());
            readTestModel.StartGame();
            NextChallenge();
        }

        public override void NextChallenge()
        {
            readTestModel.NextChallenge();
			readTestView.NextChallenge(readTestModel.CurrentQuestion);
        }

        internal void CheckAnswer(string answer)
        {
            if (readTestModel.CheckAnswer(answer))
            {
                CorrectAnswer();
            } else
            {
                WrongAnswer();
            }
        }

        private void WrongAnswer()
        {
			Debug.Log ("Wrong");
            readTestView.WrongAnswer();
        }

        private void CorrectAnswer()
        {
			Debug.Log ("Correct");
            readTestView.CorrectAnswer();
            if (GameIsEnded())
            {
                EndGame(readTestModel.GetMinSeconds(), readTestModel.GetPointsPerSecond(), readTestModel.GetPointsPerError());
            } else
            {
                NextChallenge();
            }
            
        }

        private bool GameIsEnded()
        {
            // todo
            return 1 == TO_END;
        }      

		public static ReadTestController GetController()
        {
            return readTestController;
        }

      
    }
}
