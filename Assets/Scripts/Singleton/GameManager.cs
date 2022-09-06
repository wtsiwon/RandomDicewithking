using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool isGameOver;

    public List<Array<Container>> Containers = new List<Array<Container>>();

    public List<Container> selectContainers = new List<Container>();

    private const uint MAXX = 5;
    private const uint MAXY = 3;
    /// <summary>
    /// 랜덤으로 숫자를 뽑자
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public float RandNumfloat(float min, float max)
    {
        float rand = Random.Range(min, max);
        return rand;
    }

    public int RandNumint(int min, int max)
    {
        return Random.Range(min, max);
    }

    public void GameOver()
    {

    }
    /// <summary>
    /// 주사위를 스폰할 수 있는지 확인함
    /// </summary>
    public void DiscriminateContainer()
    {
        selectContainers.Clear();
        for (int i = 0; i < MAXX; i++)
        {
            for (int j = 0; j < MAXY; j++)
            {
                if(CheckIsDice(Containers[i].ls[j]) == true)
                {
                    selectContainers.Add(Containers[i].ls[j]);
                }
            }
        }
    }
    /// <summary>
    /// Container에 Dice가 있는지 확인하는 함수
    /// </summary>
    /// <param name="con">확인할 Container</param>
    /// <returns></returns>
    private Container CheckIsDice(Container con)
    {
        if(CheckContainer(con) == true)
        {
            return con;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Container에 Dice가 있다면 false 없다면 true
    /// </summary>
    /// <param name="con">확인할 Container</param>
    /// <returns></returns>
    private bool CheckContainer(Container con)
    {
        return con.GetComponent<Container>().Dice == null ? true : false;
    }

}