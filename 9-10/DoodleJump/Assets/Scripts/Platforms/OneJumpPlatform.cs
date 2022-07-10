using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneJumpPlatform : MonoBehaviour
{
    private const float LIFE_TIME = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform == Player.Instance)
            StartCoroutine(Remove());
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
