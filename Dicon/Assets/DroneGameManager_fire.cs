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
        finded.text = "������ ȭ�� �� : " + score.ToString() + " / " + maxScore;
        finded.DOColor(Color.white, 1f).From(Color.green);
        if (score == maxScore)
        {
            endTxt.text = "����! ȭ�縦 ��� �����߽��ϴ�!";
            EndGame();
        }
    }
    public void UI_OFF(GameObject g)
    {
        float cooltime = 3f;
        g.transform.DOScale(0f, 1f).SetDelay(cooltime);
    }
}