﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField]
    private DiceData data;
    public DiceData Data
    {
        get => data;
        set
        {
            data = value;
            // Refresh ( 갱신 필요 )
        }
    }

    // gameObject <-> transfrom 의 관계처럼 이어주면
    public Container container;

    public List<GameObject> eyeList;

    private DiceEyes diceEyes;
    public DiceEyes DiceEyes
    {
        get => diceEyes;
        set
        {
            diceEyes = value;
            ShowDiceEyes();

            //var con1 = container.GetNear(Direction.Up);
            //var con2 = container.GetNear(Direction.Down);
            //var con3 = container.GetNear(Direction.Right);
            //var con4 = container.GetNear(Direction.Left);

            //con1.buff.increaseAttackSpeed += 10;
            //con2.buff.increaseAttackSpeed += 10;
            //con3.buff.increaseAttackSpeed += 10;
            //con4.buff.increaseAttackSpeed += 10;

            //CalDiceStatByEyeCount();

            // Attacker.cs -> DiceData마냥 하나씩 붙여놔도 될 듯
            // Attacker.Set~(~,~,~) 이거를 값이 변하면 호출해서 값을 갱신
            // Dice PowerUP Level -> DiceManager
            // ObjectManager -> List
            // CalDiceStatByEyeCount() + (PowerUp Stat) -> DiceManager + Default Stat + container buff
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //    diceEyes = DiceEyes.One;
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //    diceEyes = DiceEyes.Two;
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //    diceEyes = DiceEyes.Three;
        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //    diceEyes = DiceEyes.Four;
        //if (Input.GetKeyDown(KeyCode.Alpha5))
        //    diceEyes = DiceEyes.Five;
        //if (Input.GetKeyDown(KeyCode.Alpha6))
        //    diceEyes = DiceEyes.Six;


        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    ShowDiceEyes();
        //} 
    }

    // 눈금 스텟 증가량 반환됨
    public DiceStatInfo CalDiceStatByEyeCount()
    {
        DiceStatInfo diceStatInfo = new DiceStatInfo(0, 0);

        switch (DiceEyes)
        {
            case DiceEyes.One:
                diceStatInfo += data.diceIncrementalValueByEyeCount * 1;
                break;
            case DiceEyes.Two:
                diceStatInfo += data.diceIncrementalValueByEyeCount * 2;
                break;
            case DiceEyes.Three:
                diceStatInfo += data.diceIncrementalValueByEyeCount * 3;
                break;
            case DiceEyes.Four:
                diceStatInfo += data.diceIncrementalValueByEyeCount * 4;
                break;
            case DiceEyes.Five:
                diceStatInfo += data.diceIncrementalValueByEyeCount * 5;
                break;
            case DiceEyes.Six:
                diceStatInfo += data.diceIncrementalValueByEyeCount * 6;
                break;
            case DiceEyes.Seven:
                diceStatInfo += data.diceIncrementalValueByEyeCount * 7;
                break;
        }

        return diceStatInfo;
    }

    public void ShowDiceEyes()
    {
        for (int i = 0; i < 4; i++)
        {
            eyeList[i].gameObject.SetActive(false);
            if ((((int)diceEyes) & 1 << i) == 1 << i)
            {
                eyeList[i].gameObject.SetActive(true);
            }
        }
    }
}
