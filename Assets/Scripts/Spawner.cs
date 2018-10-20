using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawner : MonoBehaviour {
	public List<GameObject> enemyTypes;
	public List<Transform> spawnPoints;

	public int maxAmount = 20;

	[SerializeField, Range(1, 10)]
	private float spawnRate = 1;

	private float timeSinceLastSpawn = 0;
	private static Spawner _instance;
	public static Spawner Instance { get { return _instance; } }

	public bool canSpawn = true;

	private void Awake() {
		if (_instance != null && _instance != this) {
			Destroy(this.gameObject);
		}
		else {
			_instance = this;
		}
	}
	void Start() {
		if (enemyTypes.Count == 0) Debug.Log("Enemy types list empty");

		if (spawnPoints.Count == 0) spawnPoints.Add(transform);
		foreach (var item in enemyTypes) {
			SimplePool.Preload(item, maxAmount);
		}
	}


	private void Update() {
		spawnRate = Mathf.Clamp(5 - Mathf.Log((Time.time) / 120 + 1), 0.5f, 10);
		if (timeSinceLastSpawn >= spawnRate && canSpawn) {
			StartCoroutine("spawnEnemies");

			timeSinceLastSpawn = 0;
		}
		timeSinceLastSpawn += Time.deltaTime;
	}


	public void Despawn(GameObject gObject) {
		SimplePool.Despawn(gObject);
		gObject.transform.position = Spawner.Instance.getRandomSpawnPoint();

	}


	public Vector3 getRandomSpawnPoint() {
		Vector3 pos = spawnPoints.RandomElement<Transform>().position;
		return pos;
	}


	IEnumerator spawnEnemies() {
		int amount = Random.Range(1, 2);

		for (int i = 0; i < amount; i++) {


			GameObject temp = SimplePool.Spawn(enemyTypes.RandomElement<GameObject>(), getRandomSpawnPoint(), Quaternion.identity);
			temp.transform.SetParent(gameObject.transform);
			yield return new WaitForSeconds(0.5f);
		}
	}
}


public static class CollectionExtension {

	public static T RandomElement<T>(this IList<T> list) {
		return list[Random.Range(0, list.Count)];
	}

	public static T RandomElement<T>(this T[] array) {
		return array[Random.Range(0, array.Length)];
	}
}