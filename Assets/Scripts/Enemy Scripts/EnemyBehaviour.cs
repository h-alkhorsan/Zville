using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //float t;  *Hussain - I commented this out to get rid of the annoying warning message because its never used, uncomment it if you need it.
    Vector3 startPosition;
    Vector3 knockBack;
    public float speed;
    private Transform target;
    private bool risen = false;
    private ZombieAnimation zombieAnimation;
    private  WeaponManager currentWpn;
    float timeToReachTarget;
    public int zombieHealth;
    public ParticleSystem fx_Blood;
    private bool dead = false;
    private int lastBullet = -1;


    void Start()
    {
        startPosition = knockBack = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currentWpn = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponManager>();

        zombieAnimation = GetComponent<ZombieAnimation>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(zombieHealth <= 0 && !dead){
            dead = true;
            Debug.Log("Killed");
            var m_Collider = GetComponent<BoxCollider2D>();
            m_Collider.enabled = false;
            zombieAnimation.Dead();
            Destroy(gameObject,3);
        }

        float h = transform.position.x - target.position.x;
        if(risen && !zombieAnimation.isHit() && zombieHealth > 0){

            if(Mathf.Abs(h) > 1) {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            } else {
                zombieAnimation.AttackAnimation();
            } 
        }

        if(zombieAnimation.isHit() && currentWpn.getCurrentWeaponIndex() == 0){
            transform.position = Vector2.MoveTowards(transform.position, target.position, -1 * speed * Time.deltaTime);   
        }

        Vector3 tempScale = transform.localScale;
        

        if (h > 0)
        {
            tempScale.x = 1f;
        }

        else if (h < 0)
        {
            tempScale.x = -1f;
        }

        transform.localScale = tempScale;


    }
    public void Rising(){
        risen = true;
    }
    public void SetDestination(Vector3 destination, float time)
    {
        //t = 0;  See my comment above
        startPosition = transform.position;
        timeToReachTarget = time;
        knockBack = destination; 
    }
    public void DecreaseHealth(){
        var idx = currentWpn.getCurrentWeaponIndex();
        var weaponAmmo = currentWpn.currentWeapon.currentBullet;

        if(idx == 2){
            lastBullet = weaponAmmo;
        }
        fx_Blood.Play();
        if(idx == 0 ){
            zombieHealth -= 20;
        }
        if(idx == 1){
            zombieHealth -= 25;
        }
        if(idx == 2) {
            zombieHealth -= 2;
        }
        if(idx == 3){
            zombieHealth -= 50;
        }


    }
}
