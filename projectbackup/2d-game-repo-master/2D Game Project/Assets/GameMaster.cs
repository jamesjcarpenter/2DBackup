using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    void Awake()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }
    public Transform playerPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 2;
    public Transform spawnPrefab;

    public Transform enemyDeathParticles;

    public IEnumerator _RespawnPlayer() {
       GetComponent<AudioSource>().Play();
    yield return new WaitForSeconds(spawnDelay);

    Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation);
    Destroy(gameObject, 3f);
}
    public static void KillPlayer (Player player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm._RespawnPlayer());
    }
    public static void KillEnemy (Enemy enemy)
    {
        gm._KillEnemy(enemy);
    }
    public void _KillEnemy(Enemy _enemy)
    {
        Instantiate(_enemy.deathParticles, _enemy.transform.position, Quaternion.identity);
        Destroy(_enemy.gameObject);
    }
}
