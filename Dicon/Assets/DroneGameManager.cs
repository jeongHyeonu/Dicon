using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DroneGameManager : MonoBehaviour
{
    public static DroneGameManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] protected bool isStart;
    [SerializeField] protected GameObject drone_ui;
    [SerializeField] protected GameObject end_ui;
    [SerializeField] protected GameObject start_ui;
    [SerializeField] protected TextMeshProUGUI timerTxt;
    [SerializeField] protected TextMeshProUGUI endTxt;
    [SerializeField] protected TextMeshProUGUI finded;
    [SerializeField] protected float time = 120f;
    [SerializeField] protected float curTime;
    [SerializeField] protected GameObject drone;

    protected int maxScore = 5;
    protected int score;
    protected int minute;
    protected int second;

    public void StartGame()
    {
        isStart = true;
        drone_ui.SetActive(true);
        start_ui.SetActive(false);
        StartCoroutine(StartTimer());
    }

    public void EndGame()
    {
        isStart = false;
        drone_ui.SetActive(false);
        end_ui.SetActive(true);
        drone.GetComponent<DroneLeftController>().enabled = false;
        drone.GetComponent<DroneRightController>().enabled = false;
    }

    IEnumerator StartTimer()
    {
        curTime = time;
        while (curTime > 0 && isStart)
        {
            curTime -= Time.deltaTime;
            minute = (int)curTime / 60;
            second = (int)curTime % 60;
            timerTxt.text = minute.ToString("00") + ":" + second.ToString("00");
            yield return null;

            if (curTime <= 0)
            {
                curTime = 0;
                EndGame();
                yield break;
            }
        }
    }

    public void PlusScore(int _score)
    {
        score += _score;
        finded.text = "찾은 요구조자 수 : " + score.ToString() + " / " + maxScore;
        finded.DOColor(Color.white, 1f).From(Color.green);
        if(score == maxScore)
        {
            endTxt.text = "성공! 요구조자를 전부 찾았습니다!";
            EndGame();
        }
    }
}
