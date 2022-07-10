using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    [SerializeField] private AnimationCurve _scaleCurve;
    [SerializeField, Min(0)] private float _timeToClick;

    IEnumerator Start()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();

        for (float time = 0; time < _timeToClick; time += Time.deltaTime)
        {
            transform.localScale = Vector3.one * _scaleCurve.Evaluate(time / _timeToClick);
            yield return wait;
        }
        Score.Instance.MissClick();
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Score.Instance.Click();
        Destroy(gameObject);
    }
}
