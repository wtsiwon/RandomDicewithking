using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Data/Dice", fileName = "Dice", order = 0)]
public class DiceData : ScriptableObject
{
    // 총알, 주사위 사진
    public EDiceType diceType;
    public ETargetPriority targetPriority;
    public DiceStatInfo diceStatInfo;
    // 인게임에서 파워업 할때마다 여기있는 증가치로 증가함
    public DiceIncrementalValue dicePowerUpIncrementalValue;
    // 눈금에 의한 증가치
    public DiceIncrementalValue diceIncrementalValueByEyeCount;
}
