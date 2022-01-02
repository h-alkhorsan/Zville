using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip handGunSound, akSound, flameSound, gunEmpty;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        handGunSound = Resources.Load<AudioClip>("anaconda");
        akSound = Resources.Load<AudioClip>("ak47");
        flameSound = Resources.Load<AudioClip>("cryo");

        gunEmpty = Resources.Load<AudioClip>("out_of_ammo");




        audioSrc = GetComponent<AudioSource>();


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "handgun":
                audioSrc.PlayOneShot(handGunSound);
                break;

            case "ak47":
                audioSrc.PlayOneShot(akSound);
                break;

            case "flamethrower":
                audioSrc.PlayOneShot(flameSound);
                break;

            case "empty":
                audioSrc.PlayOneShot(gunEmpty);
                break;
        }
    }
    


}