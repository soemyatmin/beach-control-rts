using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

// TODO: Work in Progress Code, to connect with BtnShop,cs and CanvasManager.cs
public class TrainingQueue : MonoBehaviour
{
  public float trainingTimePerUnit = 3f;
  private Queue<ShopButtonData> queue = new Queue<ShopButtonData>();
  private bool isTraining = false;
  
  public void EnqueueSoldier(ShopButtonData soldier)
  {
    queue.Enqueue(soldier);
    if (!isTraining)
      StartCoroutine(TrainNextSoldier());
  }

  private IEnumerator TrainNextSoldier()
  {
    while (queue.Count > 0)
    {
      isTraining = true;
      ShopButtonData current = queue.Dequeue();

      Debug.Log($"Training {current.ShopBuildingName}...");
      // You can use current.Sprite or other data here as needed

      yield return new WaitForSeconds(trainingTimePerUnit);
      Debug.Log($"{current.ShopBuildingName} trained!");
    }
    isTraining = false;
  }
}