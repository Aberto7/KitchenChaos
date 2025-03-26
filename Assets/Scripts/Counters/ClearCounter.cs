using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ClearCounter : BaseCounter {

    [SerializeField] private KitchenObjectSO kitchenObjectSO;




    public override void Interact(Player player){
        if(!HasKitchenObject()){
            // There is no KitchenObject Here
            if(player.HasKitchenObject()){
                // Player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else {
                // Player is not carrying anything
            }
        } else {
            // Yes, there is a KitchenObject Here
            if (player.HasKitchenObject()){
                // Player is carrying something
            } else {
                // Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }


}
