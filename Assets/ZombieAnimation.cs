using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    private Animator anim;
    public ZombieCollider zombieCollider;
    private EnemyBehaviour zombie;
    private bool hit = false;



    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        zombie = GetComponent<EnemyBehaviour>();        
    }

    public void ZombieRunAnimation(bool run)
    {
        anim.SetBool(TagManager.RUN_PARAMETER, run);
    }

    public void AttackAnimation()
    {
        anim.SetTrigger(TagManager.ATTACK_PARAMETER);
    }

    public void Bite() {
        zombieCollider.Biting();
    }

    
    public void Hurt()
    {
        hit = true;
        zombie.DecreaseHealth();
        anim.SetTrigger(TagManager.GET_HURT_PARAMETER);
    }

    public void Dead()
    {
        var deathType = Random.Range(1,4);
        anim.SetInteger(TagManager.RANDOM_PARAMETER,deathType);
        anim.SetTrigger(TagManager.DEAD_PARAMETER);
    }

    public bool isHit(){
        return hit;
    }

    public void finishHit(){
        hit = false;
    }

    public void Rising() {
        zombie.Rising();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
