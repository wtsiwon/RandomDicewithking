using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DiceAttacker : MonoBehaviour, IAttack
{
    public Enemy targetEnemy;
    public void Attack()
    {
        targetEnemy = TargetEnemy.Instance.targetEnemyList.FirstOrDefault();
    }
}
