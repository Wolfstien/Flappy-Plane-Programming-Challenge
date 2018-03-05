using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclePooling : MonoBehaviour {

	public int obstaclePool = 5;
	public float spawnRate = 2.5f;
	public GameObject ObstaclePrefab;
	public float obstacleMin = -1.5f;
	public float obstacleMax = 2.5f;

	private float timeSinceLastSpawn;
	private GameObject[] obstacles;
	private Vector2 objectPoolPosition = new Vector2(-20f, 0f);
	private int currentObstacle = 0;

	// Use this for initialization
	void Start () 
	{
		//instantiate 5 obstacles from the obstacle prefab
		obstacles = new GameObject[obstaclePool];
		for (int i = 0; i < obstaclePool; i++) {
			obstacles [i] = (GameObject)Instantiate (ObstaclePrefab, objectPoolPosition, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeSinceLastSpawn += Time.deltaTime;
		//unlimited Zambies!!! (unlimited obstacle pool)
		if(timeSinceLastSpawn >= spawnRate)
		{
			timeSinceLastSpawn = 0;
			float spawnY = Random.Range (obstacleMin, obstacleMax);
			float spawnX = Random.Range (3.5f, 6f);

			obstacles [currentObstacle].transform.position = new Vector2 (spawnX, spawnY);
			currentObstacle++;

			if (currentObstacle>=obstaclePool) 
			{
				currentObstacle = 0;
			}
		}
	}
}
