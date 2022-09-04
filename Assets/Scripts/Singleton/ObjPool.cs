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
    [Tooltip("풀링할 오브젝트를 받아온다(Inspecter)")]
    private PoolingObj[] originObject;

    public PoolingObj Get(EPoolType poolType, Transform transform)
    {
        PoolingObj go = null;

        if(pool.ContainsKey(poolType) == false)
        {
            pool.Add(poolType,new Queue<PoolingObj>());
        }

        Queue<PoolingObj> queue = pool[poolType];

        PoolingObj origin = originObject[(int)poolType];

        if(queue.Count > 0)
        {
            go = queue.Dequeue();
        }
        else
        {
            go = Instantiate(origin);
        }

        //부모 설정
        go.transform.SetParent(transform);
        go.transform.position = Vector3.zero;
        go.gameObject.SetActive(true);

        return go;
    }


    public PoolingObj GetEnemy(EPoolType poolType, Transform transform)
    {
        return Get(poolType, transform);
    }

    public PoolingObj GetDice(EPoolType poolType, Transform transform)
    {
        return Get(poolType, transform);
    }
    public PoolingObj GetBullet(EPoolType poolType, Transform transform)
    {
        return Get(poolType, transform);
    }


    public void Return(EPoolType poolType, PoolingObj poolObj)
    {
        poolObj.gameObject.SetActive(false);
        pool[poolType].Enqueue(poolObj);
    }
}
