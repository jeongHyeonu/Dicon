using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneIndicator : MonoBehaviour
{
    [SerializeField] public GameObject targetObj;

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(targetObj.transform.position);
    }
}
