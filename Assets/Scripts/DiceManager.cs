using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DiceManager : Singleton<DiceManager>
{
    public List<DiceData> deck = new List<DiceData>();
    public const float X = 750;
    public const float Y = 1500;
    

    [SerializeField]
    private Button spawnBtn;
    [SerializeField]
    private Dice Dice;

    private void Start()
    {
        spawnBtn.onClick.AddListener(() =>
        {
            SpawnDice();
        });
    }

    private void SpawnDice()
    {
        Instantiate(Dice, transform.position, Quaternion.identity);

    }

    private Vector3 DiceSpawnPos()
    {
        
        float randx = GameManager.Instance.RandNumf(-X, X);
        float randy = GameManager.Instance.RandNumf(-Y, Y);

        return new Vector3(randx, randy, 0);
    }
    //private bool MinusOrPlus()
    //{
    //    return Random.Range(0, 2) == 1 ? true : false;
    //}




    

}
