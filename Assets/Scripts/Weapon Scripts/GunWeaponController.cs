using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunWeaponController : WeaponController 
{
    public Transform spawnPoint;
    private Transform target;
    public GameObject bulletPrefab;
    public ParticleSystem fx_Shot;
    public ParticleSystem fx_BulletFall;

    private Collider2D fireCollider;
    private WaitForSeconds waitTime = new WaitForSeconds(0.02f);
    private WaitForSeconds fireColliderWait = new WaitForSeconds(0.02f);


    // Start is called before the first frame update
    void Start()
    {
       

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public override void ProcessAttack()
    {
        var shotSFX = fx_Shot.GetComponent<Transform>();
        var shotSFXScale = shotSFX.localScale;

        var targetSide = target.localScale.x;

        if(targetSide == 1){
            shotSFXScale.x = 1;
        } else {
            shotSFXScale.x  = -1;
        }
        fx_Shot.transform.localScale = shotSFXScale;
        switch(weaponName)
        {
            case NameWeapon.HANDGUN:
                SoundManagerScript.PlaySound("handgun");
                fx_Shot.Play();
                fx_BulletFall.Play();
                break;

            case NameWeapon.AK:
                SoundManagerScript.PlaySound("ak47");
                fx_Shot.transform.localScale = shotSFXScale;    
                fx_Shot.Play();
                fx_BulletFall.Play();
                break;

            case NameWeapon.FLAMETHROWER:
                SoundManagerScript.PlaySound("flamethrower");
                fx_Shot.Play();
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
