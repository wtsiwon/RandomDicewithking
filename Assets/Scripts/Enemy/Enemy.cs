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
    private Vector3 firstTurnPos = new Vector3(0, 1000, 0);

    private Vector3 secondTurnPos = new Vector3(1500, 1000, 0);
    #endregion

    private float turnAngle = 90f;

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

        rect = GetComponent<RectTransform>();
        rb = GetComponent<Rigidbody2D>();

        #region SetStartSpd
        rb.velocity = Vector2.up * spd;

        #endregion
    }

    protected virtual void OnEnable()
    {
        //SetEnemy(hp계산식, spd계산식);
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
    }
    protected void Update()
    {
        Positions();
    }

    protected void Positions()
    {
        if(rect.position == firstTurnPos || rect.position == secondTurnPos)
        {
            rect.rotation = Quaternion.Euler(0, 0, turnAngle);
        }
    }
}