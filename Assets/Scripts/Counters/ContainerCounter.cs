using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : BaseCounter {
    
    public event EventHandler OnPlayerGrabbedObject;


    [SerializeField] private KitchenObjectSO kitchenObjectSO;




    public override void Interact(Player player){
        if (!player.HasKitchenObject()){
            // Player is not carrying anything
            KitchenObject.SpawnkitchenObject(kitchenObjectSO, player);
         
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }

    
}
