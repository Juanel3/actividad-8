using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                var objs = FindObjectsOfType(typeof(T)) as T[];
                if(objs.Length > 0)
                {
                    instance = objs[0];
                }

                if(objs.Length > 1)
                {
                    Debug.LogWarning("There are more than one " + typeof(T).Name + " in the scene.");
                }
            }
            return instance;
        }
    }
}
