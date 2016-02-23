using Assets.Scripts.App;
using UnityEngine;

namespace Assets.Scripts._Levels
{

    public abstract class LevelController : MonoBehaviour
    {

        public abstract void NextChallenge();
        public abstract void InitGame();
        
        public void EndGame(int minSeconds, int pointsPerSecond, int pointsPerError)
        {
            // todo
        }

       
    }
}
