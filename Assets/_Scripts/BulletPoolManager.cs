using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// TODO: Bonus - make this class a Singleton!

//[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    private static BulletPoolManager _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public static BulletPoolManager GetInstance()
    {
        return _instance;
    }
    public GameObject bullet;
    public int type = 0;


    //TODO: create a structure to contain a collection of bullets
    public List<GameObject> bulletPool;
    public List<GameObject> activeBullets;
    //public List<GameObject> normalBullets;
    //public List<GameObject> redBullets;
    //public List<GameObject> greenBullets;
    //public List<GameObject> blueBullets;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: add a series of bullets to the Bullet Pool
        for (int i = 0; i < 20; i++)
        {
            bulletPool.Add(CreateInstance(0));
        }

        foreach (GameObject Bullet in bulletPool)
        {
            Bullet.gameObject.SetActive(false);
            Bullet.transform.parent = this.transform;
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            type = 0;
            //bulletPool = normalBullets;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            type = 1;
            //bulletPool = redBullets;
            //if (bulletPool.Count == 20)
            //{
            //    for (int i = bulletPool.Count - 1; i >= 0; i--)
            //    {
            //        Destroy(bulletPool[i]);
            //        //bulletPool.RemoveAt(i);
            //    }
            //    bulletPool.Clear();
            //    for (int i = 0; i < 20; i++)
            //    {
            //        bulletPool.Add(CreateInstance(type));
            //    }
            //}
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            type = 2;
            //bulletPool = greenBullets;
            //if (bulletPool.Count == 20)
            //{
            //    for (int i = bulletPool.Count - 1; i >= 0; i--)
            //    {
            //        Destroy(bulletPool[i]);
            //        //bulletPool.RemoveAt(i);
            //    }
            //    bulletPool.Clear();
            //    for (int i = 0; i < 20; i++)
            //    {
            //        bulletPool.Add(CreateInstance(type));
            //    }
            //}
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            type = 3;
            //bulletPool = blueBullets;
            //if (bulletPool.Count == 20)
            //{
            //    for (int i = bulletPool.Count - 1; i >= 0; i--)
            //    {
            //        Destroy(bulletPool[i]);
            //        //bulletPool.RemoveAt(i);
            //    }
            //    bulletPool.Clear();
            //    for (int i = 0; i < 20; i++)
            //    {
            //        bulletPool.Add(CreateInstance(type));
            //    }
            //}
        }
    }

    public GameObject CreateInstance(int type)
    {
        GameObject newInstance = MonoBehaviour.Instantiate(bullet, Vector3.zero, Quaternion.identity);

        Renderer renderer = newInstance.GetComponent<Renderer>();
        switch (type)
        {
            case 0:
                break;
            case 1:
                renderer.material.SetColor("_Color", new Color(1.0f, 0.0f, 0.0f, 1.0f));
                break;
            case 2:
                renderer.material.SetColor("_Color", new Color(0.0f, 1.0f, 0.0f, 1.0f));
                break;
            case 3:
                renderer.material.SetColor("_Color", new Color(0.0f, 0.0f, 1.0f, 1.0f));
                break;
            default:
                break;
        }

        return newInstance;
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet(Vector3 pos)
    {
        activeBullets.Add(bulletPool[bulletPool.Count - 1].gameObject);
        GameObject temp = activeBullets[activeBullets.Count - 1].gameObject;
        temp.gameObject.SetActive(true);
        temp.transform.position = pos;

        bulletPool.RemoveAt(bulletPool.Count - 1);

        return temp;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        bulletPool.Add(bullet);
        bullet.gameObject.SetActive(false);

        activeBullets.Remove(bullet);
    }
}
