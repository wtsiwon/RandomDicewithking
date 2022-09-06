using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������Ʈ Ǯ���� ������ Object�� ��� �ޱ�
[RequireComponent(typeof(BoxCollider2D))]
public class PoolingObj : BaseAll
{
    //�� �̷��� �ؾ� �ұ�
    public EPoolType poolType;

    public virtual void Die()
    {
        ObjPool.Instance.Return(poolType, this);
    }


}