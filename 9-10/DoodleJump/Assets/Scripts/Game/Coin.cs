using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour
{
    public void Keep()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<Collider2D>());
        Invoke(nameof(Remove), audioSource.clip.length);
    }

    private void Remove()
    {
        Destroy(gameObject);
    }
}
