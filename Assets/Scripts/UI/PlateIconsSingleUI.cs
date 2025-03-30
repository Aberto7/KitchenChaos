using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlateIconsSingleUI : MonoBehaviour {


    [SerializeField] private Image image;

    public void SetKitchenObjectSO(KitchenObjectSO kitchenObjectSO){
        image.sprite = kitchenObjectSO.sprite;
    }
}