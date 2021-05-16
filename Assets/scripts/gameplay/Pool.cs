using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Pool
{
    static GameObject Bullet;
    static List<GameObject> BulletPool;

    static int bulletCount;

    static GameObject Anime;
    static List<GameObject> AnimePool;
    static int animeCount;

    public static int BulletCount
    {
        get => bulletCount;
    }

    public static int AnimeCount
    {
        get => animeCount;
    }

    public static void Initialize()
    {
        Bullet = Resources.Load<GameObject>("Bullet");
        BulletPool = new List<GameObject>(10);
        Anime = Resources.Load<GameObject>("Anime");
        AnimePool = new List<GameObject>(4);
        for (int i = 0; i < BulletPool.Capacity; i++)
        {
            BulletPool.Add(GetNewBullet());
        }
        for (int i = 0; i < AnimePool.Capacity; i++)
        {
            AnimePool.Add(GetNewAnime());
        }
    }

    public static GameObject GetBullet()
    {
        if (BulletPool.Count > 0)
        {
            GameObject Bullet = BulletPool[BulletPool.Count - 1];
            BulletPool.RemoveAt(BulletPool.Count - 1);
            bulletCount++;
            return Bullet;
        }
        else
        {
            BulletPool.Capacity++;
            return GetNewBullet();
        }
    }

    public static void ReturnBullet(GameObject Bullet)
    {
        Bullet.SetActive(false);
        BulletPool.Add(Bullet);
        bulletCount--;
    }

    static GameObject GetNewBullet()
    {
        GameObject bullet = GameObject.Instantiate(Bullet);
        bullet.GetComponent<Bullet>().Initialize();
        bullet.SetActive(false);
        GameObject.DontDestroyOnLoad(bullet);
        return bullet;
    }

    public static GameObject GetAnime()
    {
        if (AnimePool.Count > 0)
        {
            GameObject Anime = AnimePool[AnimePool.Count - 1];
            AnimePool.RemoveAt(AnimePool.Count - 1);
            animeCount++;
            return Anime;
        }
        else
        {
            AnimePool.Capacity++;
            return GetNewAnime();
        }
    }

    public static void ReturnAnime(GameObject anime)
    {
        anime.SetActive(false);
        AnimePool.Add(anime);
        animeCount--;
    }

    static GameObject GetNewAnime()
    {
        GameObject anime = GameObject.Instantiate(Anime);
        anime.GetComponent<Anime>().Initialize();
        anime.SetActive(false);
        GameObject.DontDestroyOnLoad(anime);
        return anime;
    }
}
