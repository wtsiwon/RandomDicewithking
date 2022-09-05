using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EDiceType
{
    None,
    Rock,
    Fire,
    Ice,
}

public enum ETargetPriority
{
    First,
    Random,
}
public enum EEnemyType
{
    None,
    Basic,
    Big,
    Boss,
}

public enum EBossType
{
    None,
    Snake,
    Silence,
}

[Flags]
public enum EDiceEyes
{
    // enum => int
    // enum(int) | enum(int)
    // 0111 (2)
    //A = 1 << 0, // 0001
    //B = 1 << 2, // 0100
    // A | B =>    0101
    //C = 5,

    None = 0,
    One = 1 << 0,
    Two = 1 << 1,
    Three = One | Two,
    Four = 1 << 2 | Two,
    Five = Four | One,
    Six = 1 << 3 | Four,
    Seven = 1 << 4,

    // for ( int i = 0 ; i < 5; ++ i )
    // 1 << i
    // index => 
}



[Serializable]
public struct DiceStatInfo
{
    public DiceStatInfo(float defaultAttackDamage, float defaultAttackSpeed)
    {
        this.defaultAttackDamage = defaultAttackDamage;
        this.defaultAttackSpeed = defaultAttackSpeed;
    }

    [Range(0, 100)]
    public float defaultAttackDamage;
    [Range(0, 20)]
    public float defaultAttackSpeed;

    public static DiceStatInfo operator +(DiceStatInfo a, DiceIncrementalValue b)
    {
        return new DiceStatInfo(a.defaultAttackDamage + b.increaseAttackSpeed, a.defaultAttackSpeed + b.increaseAttackSpeed);
    }
}

public struct DiceIncrementalValue
{
    public DiceIncrementalValue(float increaseAttackDamage, float increaseAttackSpeed)
    {
        this.increaseAttackDamage = increaseAttackDamage;
        this.increaseAttackSpeed = increaseAttackSpeed;
    }

    public float increaseAttackDamage;
    public float increaseAttackSpeed;

    public static DiceIncrementalValue operator *(DiceIncrementalValue a, float b)
    {
        return new DiceIncrementalValue(a.increaseAttackDamage * b, a.increaseAttackSpeed * b);
    }
}

public struct DiceContainerPosition
{
    public DiceContainerPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int x;
    public int y;

    //                                                      => (return)
    public DiceContainerPosition Near(Direction direction) => direction switch
    {
        Direction.Up => new DiceContainerPosition(x, y - 1),
        Direction.Down => new DiceContainerPosition(x, y + 1),
        Direction.Left => new DiceContainerPosition(x + 1, y),
        Direction.Right => new DiceContainerPosition(x - 1, y),
        _ => this,
    };

    // Debug.Log($"{식}");

    // switch "문", "식"
    // if "문"
    // while "문"
    // for "문"

    // 2 + 2
    // { }

    public int Index => Defines.BoardSize.x * y + x;
}

public struct EnemyStatInfo
{
    public EnemyStatInfo(float hp, float spd)
    {
        this.hp = hp;
        this.spd = spd;
    }

    [Range(0, 5000)]
    public float hp;
    [Range(0, 10)]
    public float spd;

    //public static EnemyStatInfo operator- (EnemyStatInfo op1, float op2)
    //{
    //    return new EnemyStatInfo(op1.hp)
    //}
    //연산자를 쓰면 둘다 바꿔야하는데 안쓰는게 맞을것인가...
}

[Serializable]
public struct Array<T>
{
    public List<T> ls;
}

public enum Direction
{
    None,
    Up,
    Down,
    Right,
    Left,
}

public static class Defines
{
    public static (int x, int y) BoardSize = (5, 3);
}
