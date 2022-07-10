using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public void Keep()
    {
        Invoke(nameof(Remove), 0);
    }

    private void Remove()
    {
        Destroy(gameObject);
    }
}
