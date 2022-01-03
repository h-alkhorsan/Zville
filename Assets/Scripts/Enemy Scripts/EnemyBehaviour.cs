using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    private Transform target;
    private ZombieAnimation zombieAnimation;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        zombieAnimation = GetComponent<ZombieAnimation>();        
    }

    // Update is called once per frame
    void Update()
    {

        float h = transform.position.x - target.position.x;

        if(Mathf.Abs(h) > 1) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        } else {
            zombieAnimation.AttackAnimation();
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
}
