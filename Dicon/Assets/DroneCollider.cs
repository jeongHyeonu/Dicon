using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DroneCollider : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI durabilityTxt;
    [SerializeField] TextMeshProUGUI endTxt;
    [SerializeField] DroneGameManager droneGameManager;

    int max_durability = 10;
    public int durability = 0;

    private void Start()
    {
        durability = max_durability;
        durabilityTxt.text = "������ : " + durability + " / " + max_durability;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            durability--;
            durabilityTxt.text = "������ : " + durability + " / " + max_durability;
            durabilityTxt.DOColor(Color.white, .5f).From(Color.red);

            if (durability <= 0)
            {
                endTxt.text = "����! - ����� ���� �浹�Ͽ� ���� �߻�";
                droneGameManager.EndGame();
            }
        }
    }
}
