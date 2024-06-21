using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneWater : MonoBehaviour
{
    public DroneGameManager_fire gm_f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "fire")
        {
            other.gameObject.transform.DOScale(0f, 1f).OnComplete(()=> {
                Destroy(other.gameObject);
                gm_f.PlusScore_fire(1);
            });
            Destroy(this.gameObject);
        }
    }
}
