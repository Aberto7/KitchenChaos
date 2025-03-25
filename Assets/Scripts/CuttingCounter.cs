using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter {


    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;


    public override void Interact(Player player){
        if(!HasKitchenObject()){
            // There is no KitchenObject Here
            if(player.HasKitchenObject()){
                // Player is carrying something
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())){
                    // Player is carrying something that can be Cut
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
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
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO())){
            // There is a KitchenObject here    AND     it can be cut 
            KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
            GetKitchenObject().DestroySelf();
            
            KitchenObject.SpawnkitchenObject(outputKitchenObjectSO, this);
        }
    }


    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO){
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray){
            if (cuttingRecipeSO.input == inputKitchenObjectSO){
                return true;
            }
        }
        return false;
    }


    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO){
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray){
            if (cuttingRecipeSO.input == inputKitchenObjectSO){
                return cuttingRecipeSO.output;
            }
        }
        return null;
    }
}