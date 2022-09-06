using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolingObj
{
    private float dmg;
    private Enemy target;
    public Bullet()
    {

    }

    public void SetBullet(float dmg, Enemy target)
    {
        this.dmg = dmg;
        this.target = target;
    }
    
    private void Update()
    {
        if(target == null)
        {
            Return();
        }
    }

    private void Return()
    {
        base.Die();
    }
}
