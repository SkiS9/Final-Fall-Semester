using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject collectableObject;
        public GameObject enemyObject;
    public float areaRange = 23f;
    public int coinAmount = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateRandomAmountOfEnemies());
        SpawnCollectableObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomEnemy()
    {
        Instantiate(enemyObject, new Vector3(0, 1, 5), enemyObject.transform.rotation);
    }

    public void SpawnCollectableObject()
    {
        for (int i = 0; i < coinAmount; i++) 
        {
            Instantiate(collectableObject, CreateRandomSpawnPosition(), collectableObject.transform.rotation);
        }
    }
    Vector3 CreateRandomSpawnPosition()
    {
     float xValue = Random.Range (-areaRange, areaRange);
     float zValue = Random.Range (-areaRange, areaRange);
     Vector3 randomPosition = new Vector3(xValue, 1f, zValue);

      return randomPosition;
    }

    IEnumerator CreateRandomAmountOfEnemies()
    {
        while(true)
        {
            int randomSeconds = Random.Range(1, 8);
            yield return new WaitForSeconds(randomSeconds);

            int numberOfEnemies = Random.Range(1, 3);

            for(int i = 0; i < numberOfEnemies; i++)
            {
                SpawnRandomEnemy();
            }

        }
    }

}
