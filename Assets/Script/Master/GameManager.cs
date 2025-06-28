using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] private ShopController _shopController;
    
    public Image image;
    void Start()
    {
        MasterData.Instance.Init();
        _shopController.Init();
    }
}
