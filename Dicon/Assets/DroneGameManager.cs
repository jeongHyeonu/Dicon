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

    [SerializeField] bool isStart;
    [SerializeField] GameObject drone_ui;
    [SerializeField] GameObject end_ui;
    [SerializeField] GameObject start_ui;
    [SerializeField] TextMeshProUGUI timerTxt;
    [SerializeField] TextMeshProUGUI endTxt;
    [SerializeField] TextMeshProUGUI finded;
    [SerializeField] float time = 120f;
    [SerializeField] float curTime;

    int maxScore = 5;
    int score;
    int minute;
    int second;

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
        if(score == maxScore)
        {
            isStart = false;
            endTxt.text = "성공! 요구조자를 전부 찾았습니다!";
            EndGame();
        }
    }
}
