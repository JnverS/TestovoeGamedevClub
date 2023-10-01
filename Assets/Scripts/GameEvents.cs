using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;
    public event Action OnItemAdded;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    // Update is called once per frame
    public void InvokeInventoryChange()
    {
        OnItemAdded?.Invoke();
    }    

}
