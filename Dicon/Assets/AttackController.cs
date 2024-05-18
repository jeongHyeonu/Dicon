using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : NetworkBehaviour
{
    public int AttackDamage = 10;
    public int SkillDamage = 10;
    public int UltDamage = 10;


    public virtual void AttackButtonClick() { }
    public virtual void SkillButtonClick() { }
    public virtual void UltButtonClick() { }

}
