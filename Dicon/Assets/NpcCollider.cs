using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.tag.Equals("drone"))
        {
            DroneGameManager.instance.PlusScore(1);
            this.gameObject.SetActive(false);
        }
    }
}
