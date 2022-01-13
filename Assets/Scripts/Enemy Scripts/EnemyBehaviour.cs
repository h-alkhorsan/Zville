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
    float timeToReachTarget;

    void Start()
    {
        startPosition = knockBack = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        zombieAnimation = GetComponent<ZombieAnimation>();        
    }

    // Update is called once per frame
    void Update()
    {
        float h = transform.position.x - target.position.x;
        if(risen && !zombieAnimation.isHit()){

            if(Mathf.Abs(h) > 1) {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            } else {
                zombieAnimation.AttackAnimation();
            } 
        }

        if(zombieAnimation.isHit()){
            // t += Time.deltaTime/timeToReachTarget;
            // transform.position = Vector3.Lerp(startPosition, knockBack, t);
            // if(t == 1){
            //     zombieAnimation.setHit(false);
            // } 
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
}
