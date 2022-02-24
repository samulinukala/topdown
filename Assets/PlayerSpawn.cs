using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] float spawnDelay = 0;

    public void SpawnPlayer(GameObject player)
    {
        StartCoroutine(SpawnPlayerIE(player));
    }

    private IEnumerator SpawnPlayerIE(GameObject player)
    {
        yield return new WaitForSeconds(spawnDelay);

        int rnd = Random.Range(0, spawnPoints.Length);
        player.transform.position = spawnPoints[rnd].transform.position;
        player.SetActive(true);
    }
}