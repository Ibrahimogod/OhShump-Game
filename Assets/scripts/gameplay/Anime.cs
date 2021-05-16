using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anime : MonoBehaviour
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

    private void OnBecameInvisible()
    {
        StopMoving();
        Pool.ReturnAnime(gameObject);
    }

    private void OnBecameVisible()
    {
        StartMoving();
    }

    void StartMoving()
    {
        rb2d.AddForce(new Vector2(-5, 0), ForceMode2D.Impulse);
    }

    void StopMoving()
    {
        rb2d.velocity = Vector2.zero;
    }
}
