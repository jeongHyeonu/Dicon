using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_start : MonoBehaviour
{
    [SerializeField] GameObject NPC_set;

    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            int r = Random.Range(0, 10);
            NPC_set.transform.GetChild(r).gameObject.SetActive(false);
        }
    }
}
