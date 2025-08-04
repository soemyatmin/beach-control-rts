using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO: Work in Progress Code, to connect with BtnShop,cs and CanvasManager.cs
public class TrainingQueue : MonoBehaviour {
  
  private Queue<BtnShop> queue = new Queue<BtnShop>();
  private bool isTraining = false;

  public void EnqueueUnit(BtnShop unitButton) {
    queue.Enqueue(unitButton);
    // unitButton.refreshCount();
    if (!isTraining){
      StartCoroutine(TrainNextSoldier(unitButton));
    }
  }
  
  private IEnumerator TrainNextSoldier(BtnShop unitButton) {
    while (queue.Count > 0) {
      isTraining = true;
      BtnShop current = queue.Dequeue();
      // unitButton.refreshCount();

      yield return new WaitForSeconds(unitButton.GetShopBuilding().ShopBuildingBuildDuration);
      unitButton.OnCooldownFinished();
    }
    isTraining = false;
  }
  
  public void RemoveSoldier(BtnShop unitButton) {
    Queue<BtnShop> newQueue = new Queue<BtnShop>();

    foreach (var soldier in queue) {
      if (soldier != unitButton) {
        newQueue.Enqueue(soldier);
      }
    }

    queue = newQueue;
    // unitButton.refreshCount();
  }
  
  public bool limitQueueCount() {
    return true;
  }
}