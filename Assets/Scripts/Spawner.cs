using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawner : MonoBehaviour
{
    public List<GameObject> toSpawnTypes;
    public List<Transform> spawnPoints;

    public int maxAmount = 20;

    [SerializeField, Range(1, 10)]
    private float spawnRate = 1;

    private float timeSinceLastSpawn = 0;
    private static Spawner _instance;
    public static Spawner Instance { get { return _instance; } }

    public bool canSpawn = true;

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
    void Start()
    {
        if (toSpawnTypes.Count == 0) Debug.Log("Types list empty");

        if (spawnPoints.Count == 0) spawnPoints.Add(transform);
        foreach (var item in toSpawnTypes)
        {
            SimplePool.Preload(item, maxAmount);
        }
    }

    public virtual float SpawnRate()
    {
        return Mathf.Clamp(5 - Mathf.Log((Time.time) / 120 + 1), 0.5f, 10);
    }
    private void Update()
    {
        spawnRate = SpawnRate();
        if (timeSinceLastSpawn >= spawnRate && canSpawn)
        {
            StartCoroutine("Spawn");

            timeSinceLastSpawn = 0;
        }
        timeSinceLastSpawn += Time.deltaTime;
    }


    public void Despawn(GameObject gObject)
    {
        SimplePool.Despawn(gObject);
        gObject.transform.position = Spawner.Instance.getRandomSpawnPoint();
    }


    public Vector3 getRandomSpawnPoint()
    {
        return spawnPoints.RandomElement<Transform>().position; ;
    }


    IEnumerator Spawn()
    {
        int amount = Random.Range(1 + (int)(Time.time / 10), 5 + (int)(Time.time/2));

        for (int i = 0; i < amount; i++)
        {
            GameObject temp = SimplePool.Spawn(toSpawnTypes.RandomElement<GameObject>(), getRandomSpawnPoint(), Quaternion.identity);
            temp.transform.SetParent(gameObject.transform);
            yield return new WaitForSeconds(0.2f);
        }
    }
}


public static class CollectionExtension
{

    public static T RandomElement<T>(this IList<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}