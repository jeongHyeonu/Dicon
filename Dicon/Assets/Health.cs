using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : NetworkBehaviour
{
    [Networked, OnChangedRender(nameof(HealthChanged))]
    public float NetworkedHealth { get; set; } = 100;

    public float maxHelath;

    public Slider hpSlider;

    private void Start()
    {
        maxHelath = NetworkedHealth;
    }

    void HealthChanged()
    {
        Debug.Log($"Health changed to: {NetworkedHealth}");
    }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void DealDamageRpc(int damage)
    {
        // The code inside here will run on the client which owns this object (has state and input authority).
        Debug.Log("Received DealDamageRpc on StateAuthority, modifying Networked variable");
        NetworkedHealth -= damage;
        hpSlider.value = NetworkedHealth / maxHelath;
    }
}