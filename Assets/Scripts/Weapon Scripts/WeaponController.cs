using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum NameWeapon
{
    BAT,
    HANDGUN,
    AK,
    FLAMETHROWER
}

public class WeaponController : MonoBehaviour
{
    public DefaultConfig defaultConfig;
    public NameWeapon weaponName;

    protected PlayerAnimations playerAnim;
    protected float lastShot;


    public int gunIndex;
    public int currentBullet;
    public int bulletMax;




    public void Awake()
    {
        playerAnim = GetComponentInParent<PlayerAnimations>();
        currentBullet = bulletMax;

    }

    public void CallAttack()
    {
        if (Time.time > lastShot + defaultConfig.fireRate)
        {
            if (currentBullet > 0)
            {
                ProcessAttack();

                Debug.Log("Attacking");

                // Shoot animation
                playerAnim.AttackAnimation();



                lastShot = Time.time;
                currentBullet--;

            }

            else
            {
                // Play no ammo sound
                SoundManagerScript.PlaySound("empty");
            }
        }
    }

    public virtual void ProcessAttack()
    {
        
    }




    void Update()
    {
        
    }
}
