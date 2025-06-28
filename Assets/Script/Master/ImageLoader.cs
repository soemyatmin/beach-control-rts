using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoader : SingletonMonoBehaviour<ImageLoader>
{
    public Sprite LoadImageByName(string name)
    {
        Sprite loadedSprite = Resources.Load<Sprite>(name);
        if (loadedSprite != null)
        {
            return loadedSprite;
        }
        else
        {
            Debug.LogWarning("Failed to load image: " + name);
        }
        return null;
    }
}
