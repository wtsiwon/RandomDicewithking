using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//오브젝트 풀링을 적용할 Object만 상속 받기
[RequireComponent(typeof(BoxCollider2D))]
public class PoolingObj : BaseAll
{
    //왜 이렇게 해야 할까
    public EPoolType poolType;

    public virtual void Die()
    {
        ObjPool.Instance.Return(poolType, this);
    }


}