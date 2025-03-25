using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter {


    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;


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


    public override void InteractAlternate(Player player){
        if (HasKitchenObject()){
            // There is a KitchenObject here
            GetKitchenObject().DestroySelf();

            Debug.Log("Alternate Works");
            
            Transform kitchenObjectTransform = Instantiate(cutKitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
    }
}