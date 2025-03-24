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
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        } else {
            // Yes, there is a KitchenObject Here
        }
    }


}
