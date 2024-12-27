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
            _timer.SetActive(true);
            _timerCoroutine = StartCoroutine(TimerCoroutine());
        }

        public void StopTimer()
        {
            if (_timerCoroutine != null)
            {
                StopCoroutine(_timerCoroutine);
                _timerCoroutine = null;
            }
        }

        private IEnumerator TimerCoroutine()
        {
            for (var timerCount = _initialCount; timerCount >= 0; timerCount--)
            {
                _timerText.text = timerCount.ToString();
                yield return new WaitForSecondsRealtime(1);
            }
            _timerText.text = "";
            TimerFinish?.Invoke();
            _timer.SetActive(false);
            yield break;
        }
    }
}
