using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneTriggerEventHandler : MonoBehaviour
{
    [SerializeField] GameObject ui_msg;
    [SerializeField] GameObject newTarget;
    [SerializeField] DroneIndicator di;

    [SerializeField] GameObject droneExtinguisher;
    [SerializeField] GameObject sprayBtn;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "drone")
        {
            ui_msg.SetActive(true);
            di.targetObj = newTarget;
            Destroy(this);
            if (this.gameObject.name == "Car_Trigger")
            {
                droneExtinguisher.SetActive(true);
                sprayBtn.SetActive(true);
            }
        }
    }
}
