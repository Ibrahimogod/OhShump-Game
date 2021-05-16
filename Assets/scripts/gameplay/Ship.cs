using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    Rigidbody2D rb2d;
    float halfHight;
    // Start is called before the first frame update
    void Start()
    {
        halfHight = GetComponent<BoxCollider2D>().size.y / 2;
        transform.position = new Vector3(ScreenUtils.ScreenLeft + halfHight, 0);
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 bulletPosition = transform.position;
            GameObject bullet = Pool.GetBullet();
            bullet.transform.position = bulletPosition;
            bullet.SetActive(true);

        }
    }

    void FixedUpdate()
    {
        float input = Input.GetAxis("Vertical");
        if (input != 0)
        {
            Vector2 position = transform.position;
            position.y += input * 7 * Time.deltaTime;
            position.y = CalculateClampedy(position.y);
            rb2d.MovePosition(position);
        }
    }

    float CalculateClampedy(float y)
    {
        // clamp left and right edges
        if (y - halfHight < ScreenUtils.ScreenBottom)
        {
            y = ScreenUtils.ScreenBottom + halfHight;
        }
        else if (y + halfHight > ScreenUtils.ScreenTop)
        {
            y = ScreenUtils.ScreenTop - halfHight;
        }
        return y;
    }
}
