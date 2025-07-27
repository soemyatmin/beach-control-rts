using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalLoader : SingletonMonoBehaviour<UniversalLoader> {
  public T LoadResourceByName<T>(string name) where T : UnityEngine.Object {
    T loadedResource = Resources.Load<T>(name);
    if (loadedResource != null) {
      return loadedResource;
    } else {
      Debug.LogWarning($"Failed to load resource of type {typeof(T)}: {name}");
      return null;
    }
  }
}