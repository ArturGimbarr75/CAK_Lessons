using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinKeeper : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsCounter;
    private int _count = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            _count++;
            coin.Keep();
            if (_coinsCounter != null)
                _coinsCounter.text = $"Count: {_count}";
        }
    }
}
