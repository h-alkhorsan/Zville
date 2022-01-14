using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class HouseEntryScript : MonoBehaviour
{

    public GameObject player;
    public WeaponController pistolController;
    public WeaponController ak47Controller;
    public WeaponController flameThrowerController;

    Vector3 playerVector;
    List<Vector3> entryPoints = new List<Vector3>();
    List<WeaponController> weapons = new List<WeaponController>();
    private bool isActive;
    private bool stop;
    Random rand = new Random();




    void Start()

    {   

        isActive = true;
        foreach(GameObject entryPoint in GameObject.FindGameObjectsWithTag("Entry"))
        {
            entryPoints.Add(entryPoint.transform.position);
        }


        weapons.Add(pistolController);
        weapons.Add(ak47Controller);
        weapons.Add(flameThrowerController);
    }

    void Update()


    {
        playerVector = player.transform.position;


        int range = 2; //range between player and house door

        foreach(Vector3 entryVector in entryPoints)
        {
            if (Vector3.Distance(playerVector, entryVector) < range)
            {
                // prompt player to enter house
                if (Input.GetKey(KeyCode.W))
                {
                    if (isActive)
                    {
                        // play open door animation
                        player.SetActive(false); //make player invisible

                        // At this point zombies should be going random directions

                        // give ammo, show how much

                        int randomAmmo = rand.Next(10, 30);
                        int randIndex = rand.Next(weapons.Count);

                        
                       /* 
                        *Hussain
                        This part is weird, it only updates the ammo for the current weapon the 
                        player is holding and not the random index of the weapon

                        Also the gun ammo increases by a massive amount, most likely due to the while loop
                        so maybe we can try slow it down or set a limit on how much it can increase
                        
                        */

                        weapons[randIndex].currentBullet += randomAmmo;

                     }

                }
            }

        }


        // Appear again
        if (Input.GetKey(KeyCode.S))
        {
            player.SetActive(true);
            isActive = true;
        }

    }



}