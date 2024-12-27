using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace ShootEmUp
{
    public class InitialGameTimer : MonoBehaviour
    {
        public event Action TimerFinish;

        [SerializeField] private GameObject _timer;        
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private int _initialCount;

        private Coroutine _timerCoroutine;

        public void StartTimer()
        {
            _timerCoroutine = StartCoroutine(TimerCoroutine());
        }

        private IEnumerator TimerCoroutine()
        {
            _timer.SetActive(true);
            for (var timerCount = _initialCount; timerCount >= 0; timerCount--)
            {
                _timerText.text = timerCount.ToString();
                yield return new WaitForSecondsRealtime(1);
            }
            _timerText.text = "";
            _timer.SetActive(false);
            TimerFinish?.Invoke();
            yield break;
        }
    }
}
