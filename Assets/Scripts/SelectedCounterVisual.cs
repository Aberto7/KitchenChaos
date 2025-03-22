using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    // We counld have used the SerializedField to drag n drop the reference but that
    // -would have been tedious, as we will be having at least a dozen counters.
    // That is Why I am using Sinleton patern here.


    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e){
        throw new System.NotImplementedException();
    }
}

