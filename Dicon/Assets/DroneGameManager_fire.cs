using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DroneGameManager_fire : DroneGameManager
{
    public void PlusScore_fire(int _score)
    {
        score += _score;
        finded.text = "진압한 화재 수 : " + score.ToString() + " / " + maxScore;
        finded.DOColor(Color.white, 1f).From(Color.green);
        if (score == maxScore)
        {
            endTxt.text = "성공! 화재를 모두 진압했습니다!";
            EndGame();
        }
    }
    public void UI_OFF(GameObject g)
    {
        float cooltime = 3f;
        g.transform.DOScale(0f, 1f).SetDelay(cooltime);
    }
}