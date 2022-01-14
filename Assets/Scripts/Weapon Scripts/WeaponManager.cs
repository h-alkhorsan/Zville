using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<WeaponController> weaponsUnlocked;
    public WeaponController[] totalWeapons;

    [HideInInspector]
    public WeaponController currentWeapon;
    private int currentWeaponIndex;
    private TypeControlAttack currentTypeControl;
    private PlayerArmController[] armController;
    private BulletCollider bulletCollider;
    private PlayerAnimations playerAnim;
    private bool isShooting;

    private void Awake()
    {
        playerAnim = GetComponent<PlayerAnimations>();

        currentWeaponIndex = 1;
    }

    public int getCurrentWeaponIndex(){
        return currentWeaponIndex;
    }

    // Start is called before the first frame update
    void Start()
    {
        armController = GetComponentsInChildren<PlayerArmController>();
        bulletCollider = GetComponentInChildren<BulletCollider>();

        ChangeWeapon(weaponsUnlocked[1]);
        
        // Change weapon
        playerAnim.SwitchWeaponAnimation((int)weaponsUnlocked[currentWeaponIndex].defaultConfig.typeWeapon);
    }


    void LoadActiveWeapons()
    {
        weaponsUnlocked.Add(totalWeapons[0]);

        for (int i = 1; i < totalWeapons.Length; i++)
        {
            weaponsUnlocked.Add(totalWeapons[i]);
        }
    }

    public void SwitchWeapon()
    {
        currentWeaponIndex++;
        currentWeaponIndex = (currentWeaponIndex >= weaponsUnlocked.Count) ? 0 : currentWeaponIndex;

        playerAnim.SwitchWeaponAnimation((int)weaponsUnlocked[currentWeaponIndex].defaultConfig.typeWeapon);

        ChangeWeapon(weaponsUnlocked[currentWeaponIndex]);


    }

    void ChangeWeapon(WeaponController newWeapon)
    {
        if (currentWeapon)
            currentWeapon.gameObject.SetActive(false);

        currentWeapon = newWeapon;
        currentTypeControl = newWeapon.defaultConfig.typeControl;

        newWeapon.gameObject.SetActive(true);

        if(newWeapon.defaultConfig.typeWeapon == TypeWeapon.TwoHand)
        {
            for (int i = 0; i < armController.Length; i++)
            {
                armController[i].ChangeToTwoHand();
            }
        }

        else
        {
            for (int i = 0; i > armController.Length; i++)
            {
                armController[i].ChangeToOneHand();
            }
        }
    }

    public void Attack()
    {
        if (currentTypeControl == TypeControlAttack.Hold)
        {
            currentWeapon.CallAttack();
            if(currentWeapon.currentBullet != 0){
                bulletCollider.Shooting(currentWeaponIndex);
            }
        }

        else if (currentTypeControl == TypeControlAttack.Click)
        {
            if (!isShooting)
            {
                currentWeapon.CallAttack();
                if(currentWeapon.currentBullet != 0){
                    bulletCollider.Shooting(currentWeaponIndex);
                }
                isShooting = true;
            }
        }
        
    }

    public void ResetAttack()
    {
        isShooting = false;
    }
}
