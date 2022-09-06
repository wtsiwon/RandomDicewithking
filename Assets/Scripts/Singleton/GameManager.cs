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
    /// �������� ���ڸ� ����
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
    /// �ֻ����� ������ �� �ִ��� Ȯ����
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
    /// Container�� Dice�� �ִ��� Ȯ���ϴ� �Լ�
    /// </summary>
    /// <param name="con">Ȯ���� Container</param>
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
    /// Container�� Dice�� �ִٸ� false ���ٸ� true
    /// </summary>
    /// <param name="con">Ȯ���� Container</param>
    /// <returns></returns>
    private bool CheckContainer(Container con)
    {
        return con.GetComponent<Container>().Dice == null ? true : false;
    }

}