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

    public PoolingObj Get(EPoolType poolType, Vector3 pos)
    {
        PoolingObj go = null;

        if(pool.ContainsKey(poolType) == false)
        {
            pool.Add(poolType,new Queue<PoolingObj>());
        }

        Queue<PoolingObj> queue = pool[poolType];

        PoolingObj origin = originObject[(int)poolType];




        return null;
    }

    public void Return()
    {

    }
}
