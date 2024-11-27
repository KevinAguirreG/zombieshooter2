using UnityEngine;
using UnityEngine.InputSystem.Android;

public class Spawn : MonoBehaviour
{
    public GameObject zombiePrefab;
    public int counter;

    public Transform[] spawnPoints; 

    private void Start()
    {
        InvokeRepeating("SpawnZombie", 0, 1f);
    }

    void SpawnZombie()
    {
        if (--counter <= 0) 
        {
            CancelInvoke("SpawnZombie"); 
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        Instantiate(zombiePrefab, spawnPoint.position, Quaternion.identity);
    }

}
