using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{

    public WeaponController weaponController;
    public GameObject Text;


    void Start()
    {

        weaponController = GetComponent<WeaponController>();
       // Text.GetComponent<Text>().text = "x" + "10";
            //weaponController.bulletMax.ToString();
    }

    void Update()
    {   

        Text.GetComponent<Text>().text = "x" + weaponController.currentBullet.ToString();
        
    }
}
