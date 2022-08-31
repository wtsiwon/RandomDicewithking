using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public DiceContainerPosition position;

    public Container GetNear(Direction direction)
    {
        var nearPos = position.Near(direction);
        if (nearPos.x < 0 || nearPos.y < 0) return null;
        return GameManager.Instance.Containers[nearPos.x].ls[nearPos.y];
    }

    public bool GetNear(Direction direction, out Container container)
    {
        container = GetNear(direction);
        return container != null;
    }

    public DiceIncrementalValue buff;

    // gameObject <-> transform과 같은 관계가 되게
    private Dice dice;
    public Dice Dice
    {
        get => dice;
        set
        {
            dice = value;
        }
    }
}
