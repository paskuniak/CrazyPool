using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] goodBalls = null;

    [SerializeField]
    private GameObject[] badBalls = null;

    [SerializeField]
    private GameObject[] uniques = null;

    private int poolSizeFactor = 3;
    private Transform objectPoolParent;
    private List<GameObject> goodPool = new List<GameObject>();
    private List<GameObject> badPool = new List<GameObject>();
    private List<GameObject> uniquePool = new List<GameObject>();


    private void Start()
    {
        objectPoolParent = new GameObject("Pool Parent").transform;
        for (int i = 0; i < poolSizeFactor; i++)
        {
            for (int j = 0; j < goodBalls.Length; j++)
            {
                var instance = Instantiate(goodBalls[j], objectPoolParent);
                instance.SetActive(false);
                goodPool.Add(instance);
            }
            for (int j = 0; j < badBalls.Length; j++)
            {
                var instance = Instantiate(badBalls[j], objectPoolParent);
                instance.SetActive(false);
                badPool.Add(instance);
            }
            for (int j = 0; j < uniques.Length; j++)
            {
                var instance = Instantiate(uniques[j], objectPoolParent);
                instance.SetActive(false);
                uniquePool.Add(instance);
            }
        }
    }

    internal GameObject GetBall(bool good)
    {
        var pool = good ? goodPool : badPool;
        if (pool.Count > 0)
        {
            var item = pool.ElementAt(UnityEngine.Random.Range(0, pool.Count));
            item.SetActive(true);
            pool.Remove(item);
            return item;
        }
        return null;
    }

    internal GameObject GetUnique()
    {
        if (uniquePool.Count > 0)
        {
            var item = uniquePool.ElementAt(UnityEngine.Random.Range(0, uniquePool.Count));
            item.SetActive(true);
            uniquePool.Remove(item);
            return item;
        }
        return null;
    }

    internal void ReturnBall(GameObject item, bool good)
    {
        item.SetActive(false);
        var pool = good ? goodPool : badPool;
        pool.Add(item);
    }

    internal void ReturnUnique(GameObject item)
    {
        item.SetActive(false);
        uniquePool.Add(item);
    }

}
