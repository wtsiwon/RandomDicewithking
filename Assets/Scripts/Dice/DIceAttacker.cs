using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DiceAttacker : MonoBehaviour, IAttack
{
    //public Enemy targetEnemy;

    public Dice dice;

    //private DiceStatInfo StatInfo;

    private void Start()
    {
        //StatInfo = Dice.Data.diceStatInfo;
    }
    public void Attack()
    {
        //targetEnemy = TargetEnemy.Instance.targetEnemyList.FirstOrDefault();
        print("น฿ป็!");
        if (TargetEnemy.Instance.targetEnemyList.Count <= 0) return;

        var target = TargetEnemy.Instance.targetEnemyList[0];

        var dice_stat = dice.CalDiceStatByEyeCount() + dice.Data.diceStatInfo + dice.container.buff;

        ObjPool.Instance.GetBullet(transform).SetBullet(dice_stat.defaultAttackDamage, target);
    }
}