using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Housing : MonoBehaviour
{
    public GameObject SpawnPoint;
    public GameObject RundsavPrefab;
    public float speed = 10;
    public float SpawnInterval = 0.5f;

        IEnumerator Start()
    {
        GameObject spawn = Instantiate(RundsavPrefab) as GameObject; //Laver en klon af prefab, som er typen gameobject
        spawn.transform.position = SpawnPoint.transform.position; // spawner saven ind på spawnpoints' plads
        spawn.tag = "Dead";
        spawn.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0); //giver saven en hastighed
        Destroy(spawn, 1);// ødelægger saven efter 1 sekund
        yield return new WaitForSeconds(SpawnInterval); //Stopper IEnumerator, og venter i x sekunder
        StartCoroutine(Start()); //starter IEnumerator forfra
    }
}
