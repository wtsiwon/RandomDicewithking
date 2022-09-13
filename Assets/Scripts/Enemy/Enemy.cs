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

    //현재 positon의 인덱스
    public int posIndex;
    #region TurnPoses
    private float firstTurnPosy = 1000f;

    private float secondTurnPosx = 1500f;

    private Vector3 endPos = new Vector3(1500, -40, 0);
    #endregion

    protected RectTransform rect;
    protected Rigidbody2D rb;
    protected float Hp
    {
        get { return hp; }
        set
        {
            Damaged(value);
        }
    }

    protected void Awake()
    {
        GetComponents();
    }

    protected virtual void Start()
    {
    }
    protected void GetComponents()
    {
        print("GetComponents");
        rect = GetComponent<RectTransform>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnEnable()
    {
        SetEnemy();

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
        print("들어가");
        base.Die();
        TargetEnemy.Instance.targetEnemyList.Remove(this);
    }
    protected virtual void Update()
    {
        Positions();
    } 

    protected void Positions()
    {
        if(rect.localPosition.x >= secondTurnPosx)
        {
            Direction(Vector2.down);
        }
        if(rect.localPosition.y >= firstTurnPosy)
        {
            Direction(Vector2.right);
        }
    }

    protected void SetEnemy() 
    {
        posIndex = 0;
    }

    protected void Direction(Vector2 dir)
    {
        rb.velocity = dir * spd;
    }
}