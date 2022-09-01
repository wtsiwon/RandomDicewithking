using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float hp;
    protected float spd;

    protected virtual void OnEnable()
    {
        
    }
    public void SetEnemy(float hp, float spd)
    {
        this.hp = hp;
        this.spd = spd;
    }
}
