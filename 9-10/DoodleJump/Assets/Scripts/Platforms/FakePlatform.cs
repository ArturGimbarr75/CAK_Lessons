using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlatform : MonoBehaviour
{
    private const float LIFE_TIME = 0.5f;

    void Start() => GetComponent<Collider2D>().isTrigger = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == Player.Instance)
        { 
            Destroy(collision.transform.GetComponent<Collider2D>());
            StartCoroutine(Remove());
            gameObject.AddComponent<Rigidbody2D>().angularVelocity = Random.Range(360, 720);
        }
    }

    IEnumerator Remove()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color begin = sr.color, target = sr.color;
        target.a = 0;

        for (float t = 0; t < LIFE_TIME; t += Time.deltaTime)
        {
            sr.color = Color.Lerp(begin, target, t / LIFE_TIME);
            yield return wait;
        }

        Destroy(gameObject);
    }
}
