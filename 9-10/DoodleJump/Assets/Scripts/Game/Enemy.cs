using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == Player.Instance)
        {
            Player.Instance.GetComponent<Collider2D>().enabled = false;
            Player.Instance.GetComponent<PlayerHorizontalMovement>().enabled = false;
            Player.Instance.GetComponent<Rigidbody2D>().velocity = Vector2.zero;            
        }
    }
}
