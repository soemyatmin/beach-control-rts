using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalLoader : SingletonMonoBehaviour<UniversalLoader>
{
    // public Sprite LoadImageByName(string name)
    // {
    //     Sprite loadedSprite = Resources.Load<Sprite>(name);
    //     if (loadedSprite != null)
    //     {
    //         return loadedSprite;
    //     }
    //     else
    //     {
    //         Debug.LogWarning("Failed to load image: " + name);
    //     }
    //     return null;
    // }
    //
    // public GameObject LoadGameObjectByName(string name)
    // {
    //     GameObject loadedGameObject = Resources.Load<GameObject>(name);
    //     if (loadedGameObject != null)
    //     {
    //         return loadedGameObject;
    //     }
    //     else
    //     {
    //         Debug.LogWarning("Failed to load image: " + name);
    //     }
    //     return null;
    // }
    
    public T LoadResourceByName<T>(string name) where T : UnityEngine.Object
    {
        T loadedResource = Resources.Load<T>(name);
        if (loadedResource != null)
        {
            return loadedResource;
        }
        else
        {
            Debug.LogWarning($"Failed to load resource of type {typeof(T)}: {name}");
            return null;
        }
    }
}
