using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeaponController : WeaponController 
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public ParticleSystem fx_Shot;
    public GameObject fx_BulletFall;

    private Collider2D fireCollider;
    private WaitForSeconds waitTime = new WaitForSeconds(0.02f);
    private WaitForSeconds fireColliderWait = new WaitForSeconds(0.02f);

    // Start is called before the first frame update
    void Start()
    {   
        
    }

    public override void ProcessAttack()
    {
        switch(weaponName)
        {
            case NameWeapon.HANDGUN:
                break;

            case NameWeapon.AK:
                break;

            case NameWeapon.FLAMETHROWER:
                break;

       }

        
    }


    IEnumerator WaitForShootEffect()
    {
        yield return waitTime;
        fx_Shot.Play();
    }

    IEnumerator ActiveFireCollider()
    {
        fireCollider.enabled = true;
        yield return fireColliderWait;
        fireCollider.enabled = false;
    }
}
