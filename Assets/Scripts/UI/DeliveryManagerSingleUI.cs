using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeliveryManagerSingleUI : MonoBehaviour {


    [SerializeField] private TextMeshProUGUI recipeNameText;

    public void SetRecipeSO(RecipeSO recipeSO){
        recipeNameText.text = recipeSO.recipeName;
    }

}
