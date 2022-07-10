using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    [SerializeField, Min(0)] private float _additionalHeight;

    private const float INFELICITY = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == Player.Instance)
        {
            if (Player.Instance.position.y + INFELICITY < transform.position.y)
            { 
                Player.Instance.GetComponent<Collider2D>().enabled = false;
                Player.Instance.GetComponent<PlayerHorizontalMovement>().enabled = false;
                Player.Instance.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<AudioSource>().Play();
            }
            else
            {
                Rigidbody2D rigidbody = Player.Instance.GetComponent<Rigidbody2D>();
                float impulse = Mathf.Sqrt(_additionalHeight * -2 *
                    (Physics2D.gravity.y * rigidbody.gravityScale));
                rigidbody.velocity = Vector2.zero;
                rigidbody.AddForce(Vector2.up * impulse, ForceMode2D.Impulse);
                gameObject.AddComponent<Rigidbody2D>().angularVelocity = Random.Range(360, 720);
                Destroy(GetComponent<Collider2D>());
            }
        }
    }
}
