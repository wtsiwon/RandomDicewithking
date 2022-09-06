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
        GameManager.Instance.DiscriminateContainer();
        ObjPool.Instance.GetDice(RandomDiceType(),
            RandContainer(GameManager.Instance.selectContainers));
    }

    private Container RandContainer(List<Container> cons)
    {
        int rand = Random.Range(0, cons.Count);
        return cons[rand];
    }

    private EDiceType RandomDiceType()
    {
        return (EDiceType)GameManager.Instance.RandNumint(0, deck.Count);
    }

    
}
