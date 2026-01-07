using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;
using Object = UnityEngine.Object;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public bool _isGoodEnding;

        private void OnEnable()
        {
            GameEvents.OnGoodEndValidate += ValidateGoodEnd;
            GameEvents.OnEndGame += EndGame;
        }

        private void OnDisable()
        {
            GameEvents.OnGoodEndValidate -= ValidateGoodEnd;
            GameEvents.OnEndGame -= EndGame;
        }

        private void OnDestroy()
        {
            GameEvents.OnGoodEndValidate -= ValidateGoodEnd;
            GameEvents.OnEndGame -= EndGame;
        }

        private void ValidateGoodEnd()
        {
            _isGoodEnding = true;
        }

        private void EndGame()
        {
            if(_isGoodEnding) SceneManager.LoadScene("CreditsGoodEnd");
            else SceneManager.LoadScene("CreditsBadEnd");
        }
    }
}
