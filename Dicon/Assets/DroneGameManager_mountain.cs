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
        "체크무늬 치마를 입은 여성",
        "갈색 머리를 한 여성",
        "파란 티셔츠와 청바지를 입은 여성",
        "회색 셔츠와 모자를 쓴 남성",
        "모자를 쓰고 가방을 맨 여성",
        "주황색 조끼를 입은 남성",
        "갈색 자켓을 입은 민머리 남성",
        "검은 조끼를 입고 모자를 쓴 남성",
        "검은 자켓을 입고 모자를 쓴 남성",
        "빨간 티를 입은 갈색 수염의 남성"
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
                distanceTxt.text = "거리 : " + Mathf.Floor(distanceToTarget) + " (m)";
            }

            // .5초 대기
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
        finded.text = "찾은 실종자 수 : " + score.ToString() + " / " + maxScore;
        finded.DOColor(Color.white, 1f).From(Color.green);
        SetRabdomNPC();
        if (score == maxScore)
        {
            endTxt.text = "성공! 실종자를 모두 찾았습니다!";
            EndGame();
        }
    }
}
