using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DiceManager : Singleton<DiceManager>
{
    public List<DiceData> deck = new List<DiceData>();

    public int sp;

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
}
