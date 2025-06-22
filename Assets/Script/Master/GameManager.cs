using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    
    [SerializeField] private ShopController _shopController;
    void Start()
    {
        MasterData.Instance.Init();
        _shopController.Init();
    }
}
