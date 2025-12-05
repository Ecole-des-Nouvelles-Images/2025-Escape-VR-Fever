using System;
using UnityEngine;
using Utils;

namespace SalleIntro.Endgame
{
    public class EndDoor : MonoBehaviour
    {
        public static readonly int IsFrontOpen = Animator.StringToHash("isFrontOpen");
        
        [SerializeField] private GameObject _goodEndDoor;
        [SerializeField] private GameObject _badEndDoor;

        private Animator _goodDoorAnimator;
        private Animator _badDoorAnimator;
        private bool _isTimerOn;
        private bool _isGoodEnd;
        private float _time = 1f;

        private void Awake()
        {
            _goodDoorAnimator = _goodEndDoor.GetComponent<Animator>();
            _badDoorAnimator = _badEndDoor.GetComponent<Animator>();
        }

        private void Update()
        {
            if(_isTimerOn)
                _time -= Time.deltaTime;
            if (_time <= 0)
            {
                GameEvents.OnDoorOpened?.Invoke(_isGoodEnd);
            }
        }
        
    }
}
