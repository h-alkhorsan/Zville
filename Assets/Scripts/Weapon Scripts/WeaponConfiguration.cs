using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Single shot or automatic fire
public enum TypeControlAttack
{
    Click,
    Hold
}
// Type of weapon used by player
public enum TypeWeapon
{
    Melee,
    OneHand,
    TwoHand
}

// Default weapon configuration

[System.Serializable]
public struct DefaultConfig
{
    public TypeControlAttack typeControl;
    public TypeWeapon typeWeapon;

    [Range(0, 100)]
    public int damage;

    [Range(0, 100)]
    public int criticalDamage;

    [Range(0.01f, 1.0f)]
    public float fireRate;

    [Range(0, 100)]
    public int criticalRate;

}