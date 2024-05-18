using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum attackType {
    attack,
    skill,
    ult
}

public class AttackChecker : MonoBehaviour
{
    public attackType _type;

    public int attackDmg;
    public int skillDmg;
    public int ultDmg;

    public GameObject PlayerModel;

    private void Awake()
    {
        attackDmg = PlayerModel.GetComponent<AttackController>().AttackDamage;
        skillDmg = PlayerModel.GetComponent<AttackController>().SkillDamage;
        ultDmg = PlayerModel.GetComponent<AttackController>().UltDamage;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerModel) return;

        Health targetHealth = other?.GetComponent<Health>();
        if (targetHealth)
        {
            switch (_type)
            {
                case attackType.attack:
                    targetHealth.DealDamageRpc(attackDmg);
                    break;
                case attackType.skill:
                    targetHealth.DealDamageRpc(skillDmg);
                    break;
                case attackType.ult:
                    targetHealth.DealDamageRpc(ultDmg);
                    break;
            }
        }
    }

    private void OnEnable()
    {
        Invoke("disableCheck", .2f);
    }

    private void disableCheck() { gameObject.SetActive(false); }
}
