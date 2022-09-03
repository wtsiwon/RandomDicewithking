using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{


    public bool isGameOver;

    public List<Array<Container>> Containers = new List<Array<Container>>();
    /// <summary>
    /// ·£´ıÀ¸·Î ¼ıÀÚ¸¦ »ÌÀÚ
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public float RandNumf(float min, float max)
    {
        float rand = Random.Range(min, max);
        return rand;
    }

    public void GameOver()
    {

    }

}