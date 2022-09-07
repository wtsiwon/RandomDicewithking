using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolingObj
{
    private float moveTime = 0.5f;

    private float dmg;
    private Enemy target;

    public void SetBullet(float dmg, Enemy target)
    {
        this.dmg = dmg;
        this.target = target;
    }

    private void Start()
    {

    }

    private void Update()
    {
        //target이 없거나 target이 꺼져있으면 Return;
        if (target == null && target.gameObject.activeSelf == false)
        {
            Return();
        }

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveTime);
    }

    private void Return()
    {
        base.Die();
    }
}
