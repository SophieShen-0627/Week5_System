using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlock : MonoBehaviour
{
    [SerializeField] float Force = 6;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<PlayerController>())
        {
            Rigidbody2D player = collision.collider.GetComponent<Rigidbody2D>();
            Vector2 Dir = player.transform.position - transform.position;
            Vector2 force = Vector2.zero;
            if (Dir.y >= 0.4f) force = Vector2.up;
            else if (Dir.x < 0) force = new Vector2(-2, 0.2f);
            else if (Dir.x > 0) force = new Vector2(2, 0.2f);

            player.AddForce(force * Force, ForceMode2D.Impulse);
        }
    }
}
