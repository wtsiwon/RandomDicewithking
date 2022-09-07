using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EPoolType
{
    Bullet,
    BasicEnemy,
    BigEnemy,
    Dice,
    Effect,
}
public class ObjPool : Singleton<ObjPool>
{
    public Dictionary<EPoolType, Queue<PoolingObj>> pool = new Dictionary<EPoolType, Queue<PoolingObj>>();

    [SerializeField]
    [Tooltip("풀링할 오브젝트를 받아온다(Inspecter),Bullet,BasicEnemy,BigEnemy,Dice,Effect")]
    private PoolingObj[] originObject;

    public PoolingObj Get(EPoolType poolType, Transform transform)
    {
        PoolingObj go = null;

        if (pool.ContainsKey(poolType) == false)
        {
            pool.Add(poolType, new Queue<PoolingObj>());
        }

        Queue<PoolingObj> queue = pool[poolType];

        PoolingObj origin = originObject[(int)poolType];

        if (queue.Count > 0)
        {
            go = queue.Dequeue();
        }
        else
        {
            go = Instantiate(origin);
        }

        go.Get();

        //부모 설정
        go.transform.SetParent(transform);
        go.transform.localScale = Vector3.one;
        go.transform.localPosition = Vector3.zero;
        go.gameObject.SetActive(true);

        return go;
    }


    public PoolingObj GetEnemy(EEnemyType enemyType, Transform transform)
    {
        PoolingObj obj = null;
        Enemy enemy = null;
        switch (enemyType)
        {
            case EEnemyType.Basic:
                obj = Get(EPoolType.BasicEnemy, transform);
                enemy = obj.GetComponent<BasicEnemy>();
                //enemy.SetEnemy(hp, spd);
                break;
            case EEnemyType.Boss:
                obj = Get(EPoolType.BigEnemy, transform);
                enemy = obj.GetComponent<BigEnemy>();
                //enemy.SetEnemy(hp, spd);
                break;
            default:
                Debug.Assert(obj != null, "Enemy is null!");
                break;
        }
        return enemy;
    }

    //public PoolingObj GetBoss(Transform transform)
    //{
        
    //}

    public PoolingObj GetDice(EDiceType diceType, Container container)
    {

        PoolingObj obj = Get(EPoolType.Dice, container.transform);
        Dice dice = obj.GetComponent<Dice>();

        container.Dice = dice;
        dice.container = container;
        dice.DiceEyes = EDiceEyes.One;

        dice.Data = DiceManager.Instance.deck[(int)diceType];

        return dice;
    }
    public Bullet GetBullet(Transform transform)
    {
        return Get(EPoolType.Bullet, transform).GetComponent<Bullet>();
    }

    //public T Get<T>(EPoolType poolType, Transform transform)
    //{

    //}
    public void Return(EPoolType poolType, PoolingObj poolObj)
    {
        poolObj.gameObject.SetActive(false);
        pool[poolType].Enqueue(poolObj);
    }
}
