using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Analytics.Internal;
using UnityEngine;

public class DroneGameManager_mountain : DroneGameManager
{
    [SerializeField] GameObject NPC_set;
    [SerializeField] TextMeshProUGUI toFindText;
    [SerializeField] GameObject warnImage;
    [SerializeField] GameObject interactBtn;
    [SerializeField] GameObject toFindNPC;
    [SerializeField] TextMeshProUGUI distanceTxt;
    public int randomIdx;
    public int npcIdx;

    string[] npc_name =
    {
        "üũ���� ġ���� ���� ����",
        "���� �Ӹ��� �� ����",
        "�Ķ� Ƽ������ û������ ���� ����",
        "ȸ�� ������ ���ڸ� �� ����",
        "���ڸ� ���� ������ �� ����",
        "��Ȳ�� ������ ���� ����",
        "���� ������ ���� �θӸ� ����",
        "���� ������ �԰� ���ڸ� �� ����",
        "���� ������ �԰� ���ڸ� �� ����",
        "���� Ƽ�� ���� ���� ������ ����"
    };

    public void StartGame_mountain()
    {
        StartGame();
        SetRabdomNPC();
    }

    public void SetRabdomNPC()
    {
        randomIdx = Random.Range(0, 10);
        toFindNPC = NPC_set.transform.GetChild(randomIdx).gameObject;
        toFindText.text = npc_name[randomIdx];
        StartCoroutine(UpdateDistance());
    }

    IEnumerator UpdateDistance()
    {
        while (true)
        {
            if (toFindNPC != null)
            {
                float distanceToTarget = Vector3.Distance(drone.transform.position, toFindNPC.transform.position);
                distanceTxt.text = "�Ÿ� : " + Mathf.Floor(distanceToTarget) + " (m)";
            }

            // .5�� ���
            yield return new WaitForSeconds(.5f);
        }
    }

    public void InteractNPC()
    {
        interactBtn.SetActive(false);

        if (randomIdx == npcIdx)
        {
            NPC_set.transform.GetChild(npcIdx).gameObject.SetActive(false);
            PlusScore_mountain(1);
        }
        else
        {
            warnImage.transform.DOScale(1f, .3f).OnComplete(() =>
            {
                warnImage.transform.DOScale(0f, .3f).SetDelay(2f);
            });
        }
    }

    public void PlusScore_mountain(int _score)
    {
        score += _score;
        finded.text = "ã�� ������ �� : " + score.ToString() + " / " + maxScore;
        finded.DOColor(Color.white, 1f).From(Color.green);
        SetRabdomNPC();
        if (score == maxScore)
        {
            endTxt.text = "����! �����ڸ� ��� ã�ҽ��ϴ�!";
            EndGame();
        }
    }
}
