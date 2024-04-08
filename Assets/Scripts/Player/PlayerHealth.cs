using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthSystem, ICallPrefs
{
    void Start()
    {
        CallPrefs();
    }

    public override void Die()
    {
        PlayerDataManager.instance.PlayerDead();
        GameMenu.instance.EndGameFailure();
    }

    public override void ReceiveDamage(float dmg)
    {
        base.ReceiveDamage(dmg);
        SetStrings.instance.SetHealthBar(_maxHealth, _currentHealth);
    }

    public void CallPrefs()
    {
        SetHealth(PlayerPrefs.GetFloat("Health"));
    }
}