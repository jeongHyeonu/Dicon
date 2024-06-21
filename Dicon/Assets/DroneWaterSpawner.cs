using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneWaterSpawner : MonoBehaviour
{
    public GameObject waterObj;
    public float power;
    public DroneGameManager_fire gm_f;

    public void ShootWater()
    {
        StartCoroutine(shootWater());
    }

    IEnumerator shootWater()
    {
        yield return new WaitForSeconds(.3f);
        GameObject g = Instantiate(waterObj, this.transform.position, this.transform.rotation);
        g.GetComponent<Rigidbody>().AddForce(g.transform.forward * power);
        g.GetComponent<DroneWater>().gm_f = this.gm_f;
        Destroy(g, .3f);
        yield return null;
    }
}
