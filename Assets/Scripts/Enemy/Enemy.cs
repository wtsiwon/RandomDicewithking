using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : PoolingObj
{
    [SerializeField]
    protected float hp;
    [SerializeField]
    protected float spd;

    public static bool isEnemy = true;

    #region TurnPoses
    private Vector3 firstTurnPos = new Vector3(-50, 1000, 0);

    private Vector3 secondTurnPos = new Vector3(1500, 1000, 0);
    #endregion

    protected RectTransform rect;
    protected Rigidbody2D rb;
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
                Return();
            }
        }
    }

    protected virtual void Start()
    {
        GetComponents();
    }
    protected void GetComponents()
    {
        print("GetComponents");
        rect = GetComponent<RectTransform>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnEnable()
    {
        GetComponents();

        #region SetStartSpd
        Direction(Vector2.up);
        #endregion
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
            Return();
        }
    }

    protected void Return()
    {
        base.Die();
        TargetEnemy.Instance.targetEnemyList.Remove(this);
    }
    protected virtual void Update()
    {
        Positions();
    } 

    protected void Positions()
    {
        if(rect.localPosition.y >= firstTurnPos.y)
        {
            Direction(Vector2.right);
        }
        if(rect.localPosition.x >= secondTurnPos.x)
        {
            Direction(Vector2.down);
        }
    }

    protected void Direction(Vector2 dir)
    {
        rb.velocity = dir * spd;
    }
}