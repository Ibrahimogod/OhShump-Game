using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb2d;

    public void Initialize()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Anime")
        {
            Pool.ReturnAnime(collision.gameObject);
            Pool.ReturnBullet(gameObject);
        }
    }

    private void OnBecameVisible()
    {
        StartMoving();
    }

    private void OnBecameInvisible()
    {
        StopMoving();
        Pool.ReturnBullet(gameObject);
    }

    void StartMoving()
    {
        rb2d.AddForce(new Vector2(10, 0), ForceMode2D.Impulse);
    }

    void StopMoving()
    {
        rb2d.velocity = Vector2.zero;
    }
}
