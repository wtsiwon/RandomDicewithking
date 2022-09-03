using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
{
    public static T Instance { get; private set; }

    public void OnEnable()
    {
        Instance = GetComponent<T>();
    }
}
