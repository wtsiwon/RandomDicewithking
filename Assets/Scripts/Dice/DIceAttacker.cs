using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DiceAttacker : MonoBehaviour, IAttack
{
    public void Attack()
    {
        var target = TargetEnemy.Instance.targetEnemyList.FirstOrDefault();


    }
}
