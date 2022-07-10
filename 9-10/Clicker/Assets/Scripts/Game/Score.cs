using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance => _instance;

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField, Min(0)] private int _clickScore;
    [SerializeField, Min(0)] private int _missClickScore;

    private int _score = 0;

    private static Score _instance;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        _scoreText.text = "Score: 0";
    }

    void UpdateUI()
    {
        _scoreText.text = $"Score: {_score}";
    }

    public void MissClick()
    {
        _score -= _missClickScore;
        UpdateUI();
    }

    public void Click()
    {
        _score += _clickScore;
        UpdateUI();
    }
}
