using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Render sprite based on weapon being held

public class PlayerArmController : MonoBehaviour
{

    public Sprite oneHandSprite, twoHandSprite;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    public void ChangeToOneHand()
    {
        sr.sprite = oneHandSprite;
    }

    public void ChangeToTwoHand()
    {
        sr.sprite = twoHandSprite;
    }

}
