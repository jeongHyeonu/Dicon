using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogKnightAttack : AttackController
{
    public GameObject attackRangeCheckObj_1;
    public GameObject attackRangeCheckObj_2;
    public GameObject attackRangeCheckObj_3;


    public override void AttackButtonClick() 
    {
        StartCoroutine(AttackCheck(.2f, 1));
    }

    public override void SkillButtonClick()
    {

    }

    public override void UltButtonClick()
    {

    }


    IEnumerator AttackCheck(float _time, int _num)
    {
        yield return new WaitForSeconds(_time);
        switch (_num)
        {
            case 1:
                attackRangeCheckObj_1.SetActive(true);
                attackRangeCheckObj_1.SetActive(false);
                break;
            case 2:
                attackRangeCheckObj_2.SetActive(true);
                attackRangeCheckObj_2.SetActive(false);
                break;
            case 3:
                attackRangeCheckObj_3.SetActive(true);
                attackRangeCheckObj_3.SetActive(false);
                break;
        }
        
    }
}