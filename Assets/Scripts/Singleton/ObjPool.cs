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
    [Tooltip("Ǯ���� ������Ʈ�� �޾ƿ´�(Inspecter)")]
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

        if(queue.Count > 0)
        {
            go = queue.Dequeue();
        }
        else
        {
            go = Instantiate(go);

            
        }



        return go;
    }








    public void Return()
    {

    }
}
