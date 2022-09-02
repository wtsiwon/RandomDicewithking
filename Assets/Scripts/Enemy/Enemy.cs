using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float hp;
    protected float spd;
    protected float Hp
    {
        get { return hp; }
        set
        {
            if (hp > 0)
            {
                hp = value;
            }
            else
            {
                OnDie();
            }
        }
    }
    protected virtual void OnEnable()
    {
        //SetEnemy(hp����, spd����);
    }
    public void SetEnemy(float hp, float spd)
    {
        this.hp = hp;
        this.spd = spd;
    }

    public void Damaged(float dmg)
    {
        if (hp > 0)
        {
            Hp -= dmg;
        }
        else
        {
            OnDie();
        }
    }



    protected void OnDie()
    {
        //return�Լ�
    }
    public void Update()
    {

    }
}