using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreCounter; 
    [SerializeField] private TMP_Text _panelScore;

    private int _maxHeight = 0;

    private const string HIGHSCORE_PREF = "hs";

    void Update()
    {
        if (_maxHeight < Player.Instance.position.y)
        {
            _maxHeight = (int)Player.Instance.position.y;
            if (_scoreCounter != null)
                _scoreCounter.text = $"Score: {_maxHeight}";
        }
    }

    public void UpdatePanelInfo()
    {
        int highscore = PlayerPrefs.GetInt(HIGHSCORE_PREF, 0);

        if (_panelScore != null)
            _panelScore.text = $"Score: {_maxHeight}\nHighscore: {Mathf.Max(_maxHeight, highscore)}";

        if (highscore < _maxHeight)
            PlayerPrefs.SetInt(HIGHSCORE_PREF, _maxHeight);
    }
}
