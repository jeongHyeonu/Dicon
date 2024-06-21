using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcInteract : MonoBehaviour
{
    [SerializeField] Button interactBtn;
    [SerializeField] DroneGameManager_mountain gm_mountain;
    public int npcIdx;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "drone")
        {
            interactBtn.gameObject.SetActive(true);
            gm_mountain.npcIdx = npcIdx;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "drone")
        {
            interactBtn.gameObject.SetActive(false);
            gm_mountain.npcIdx = -1;
        }
    }
}
