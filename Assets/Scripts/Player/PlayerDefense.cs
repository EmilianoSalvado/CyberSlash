using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefense : MonoBehaviour
{
    [SerializeField] HealthSystem _playerHealth;
    [SerializeField] PlayerAttacks _playerAttacks;
    [SerializeField] float _damagedReceivedMultiplier;
    [SerializeField] float _damagedReceivedReducer;

    public enum PlayerParry
    {
        None,
        UpRight,
        DownRight,
        DownLeft,
        UpLeft
    }

    public enum PlayerDodge
    {
        None,
        Right,
        Left,
        Jump
    }

    [SerializeField] PlayerParry _currentParry;
    [SerializeField] PlayerDodge _currentDodge;

    public PlayerDodge CurrentDodge { get { return _currentDodge; } }

    public void SetCurrentParry(PlayerParry pp)
    {
        _currentParry = pp;
    }

    public void SetCurrentDodge(PlayerDodge pd)
    {
        _currentDodge = pd;
    }

    public void Clear()
    {
        _currentParry = PlayerParry.None;
        _currentDodge = PlayerDodge.None;
    }

    public void GetParryAttack(PlayerParry pp, float dmg)
    {
        if (pp != _currentParry)
        {
            _playerHealth.ReceiveDamage(dmg);
            return;
        }

        _playerAttacks.IncreaseAttacksCount();
    }

    public void GetDodgeAttack(PlayerDodge pd, float dmg)
    {
        if (_currentDodge == PlayerDodge.None)
        {
            _playerHealth.ReceiveDamage(dmg);
            Debug.Log(dmg);
            return;
        }

        else if (_currentDodge == pd)
        {
            dmg *= _damagedReceivedMultiplier;
            Debug.Log(dmg);
            _playerHealth.ReceiveDamage(dmg);
            return;
        }

        else if (pd != PlayerDodge.Jump && _currentDodge != PlayerDodge.Jump)
        {
            dmg *= _damagedReceivedReducer;
            Debug.Log(dmg);
            _playerHealth.ReceiveDamage(dmg);
            return;
        }

        _playerAttacks.IncreaseAttacksCount();
    }
}