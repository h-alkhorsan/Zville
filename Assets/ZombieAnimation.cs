using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    private Animator anim;
    public ZombieCollider zombieCollider;
    private EnemyBehaviour zombie;



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
        anim.SetTrigger(TagManager.GET_HURT_PARAMETER);
    }

    public void Dead()
    {
        anim.SetTrigger(TagManager.DEAD_PARAMETER);
    }

    public void Rising() {
        zombie.Rising();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
