using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance { get; private set; }

    private List<RingObject> activeObjects = new();

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void RegisterObject(RingObject obj)
    {
        if(!activeObjects.Contains(obj))
        {
            activeObjects.Add(obj);
            Debug.Log($"Pooled {obj}");
        }
    }

    public void DeregisterObject(RingObject obj)
    {
        activeObjects.Remove(obj);
    }

    public List<RingObject> GetActiveObjects()
    {
        //Debug.Log(activeObjects.Count);
        return activeObjects;
    }
}
