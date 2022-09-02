using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IAttack
{
    protected float hp;
    protected float spd;

    protected virtual void OnEnable()
    {
        //SetEnemy(hp����, spd����);
    }
    public void SetEnemy(float hp, float spd)
    {
        this.hp = hp;
        this.spd = spd;
    }
    public void Update()
    {
        
    }
    public void Attack()
    {
        Debug.Log("��¿");
    }
}
