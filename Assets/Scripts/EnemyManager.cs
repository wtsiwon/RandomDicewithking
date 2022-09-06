using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    private const float ENEMYSPAWNDELAY = 2f;

    public static bool ISBOSS;

    [SerializeField]
    private Transform spawnPoint;

    private void Start()
    {
        StartCoroutine(CEnemySpawn());
    }

    private IEnumerator CEnemySpawn()
    {
        while (true)
        {
            if (ISBOSS == true) yield return null;


            yield return new WaitForSeconds(ENEMYSPAWNDELAY);
            EnemySpawn();
        }
    }

    private void EnemySpawn()
    {
        ObjPool.Instance.GetEnemy(EEnemyType.Basic, spawnPoint);
    }
}
