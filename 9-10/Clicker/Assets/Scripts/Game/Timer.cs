using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool IsTimerEnded { get; private set; } = false;

    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private AnimationCurve _scaleCurve;

    private const int SECONDS = 3;

    IEnumerator Start()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();

        for (int i = SECONDS; i > 0; i--)
        {
            _timerText.text = i.ToString();
            for (float time = 0; time < 1; time += Time.deltaTime)
            {
                _timerText.transform.localScale = Vector3.one * _scaleCurve.Evaluate(time);
                yield return wait;
            }
        }
        _timerText.gameObject.SetActive(false);
        IsTimerEnded = true;
    }
}
