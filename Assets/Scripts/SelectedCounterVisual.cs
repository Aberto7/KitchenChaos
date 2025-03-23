using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    // We counld have used the SerializedField to drag n drop the reference but that
    // -would have been tedious, as we will be having at least a dozen counters.
    // That is Why I am using Sinleton patern here.


    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;

    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e){
        if (e.selectedCounter == clearCounter){
            Show();
        } else {
            Hide();
        }
    }

    private void Show(){
        visualGameObject.SetActive(true);
    }

    private void Hide(){
        visualGameObject.SetActive(false);
    }
}

