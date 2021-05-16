using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeSpawner : MonoBehaviour
{
    float minSpwanPosition, maxSpwanPosition;
    float hight;
    // Start is called before the first frame update
    void Start()
    {
        GameObject tempenemi = Pool.GetAnime();
        hight = tempenemi.GetComponent<BoxCollider2D>().size.y;
        minSpwanPosition = ScreenUtils.ScreenBottom + hight;
        maxSpwanPosition = ScreenUtils.ScreenTop - hight;
        Pool.ReturnAnime(tempenemi);
    }

    // Update is called once per frame
    void Update()
    {
        if (Pool.AnimeCount < 3)
        {
            Vector2 position = new Vector2(ScreenUtils.ScreenRight, Random.Range(minSpwanPosition, maxSpwanPosition));
            if (Physics2D.OverlapArea(new Vector2(position.x - hight, position.y + hight), new Vector2(position.x + hight, position.y - hight)) == null)
            {
                GameObject anime = Pool.GetAnime();
                anime.transform.position = position;
                anime.SetActive(true);
            }
        }
    }
}
