using System;

namespace Assets.Scripts._Levels
{

    public class ListenAndWriteController : LevelController
    {
        private static ListenAndWriteController listenAndWriteController;
        private ListenAndWriteModel listenAndWriteModel;
        public ListenAndWriteView listenAndWriteView;

        void Awake()
        {
            if (listenAndWriteController == null) listenAndWriteController = this;
            else if (listenAndWriteController != this) Destroy(this);
            InitGame();
        }
    

        public override void InitGame()
        {
            listenAndWriteModel = new ListenAndWriteModel();
            listenAndWriteModel.StartGame();
            NextChallenge();
        }

        public override void NextChallenge()
        {
            listenAndWriteModel.NextChallenge();
            //listenAndWriteView.NextChallenge();
        }
    }
}