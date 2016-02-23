namespace Assets.Scripts._Levels.AGame
{

    public class AGameController : LevelController
    {
        private static AGameController aGameController;
        public AGameView aGameView;
        private AGameModel aGameModel;
        private const int TO_END = 5;

        void Awake()
        {
            if (aGameController == null) aGameController = this;
            else if (aGameController != this) Destroy(this);
            InitGame();
        }

        public override void InitGame()
        {
            aGameModel = new AGameModel();
            aGameModel.StartGame();
            NextChallenge();
        }

        public override void NextChallenge()
        {
            aGameModel.NextChallenge();
            aGameView.NextChallenge(aGameModel.GetCurrentAnswer());
        }

        internal void CheckAnswer(int answer)
        {
            if (aGameModel.CheckAnswer(answer))
            {
                CorrectAnswer();
            } else
            {
                WrongAnswer();
            }
        }

        private void WrongAnswer()
        {
            aGameView.WrongAnswer();
        }

        private void CorrectAnswer()
        {
            aGameView.CorrectAnswer();
            if (GameIsEnded())
            {
                EndGame(aGameModel.GetMinSeconds(), aGameModel.GetPointsPerSecond(), aGameModel.GetPointsPerError());
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

        public static AGameController GetController()
        {
            return aGameController;
        }

      
    }
}
