using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    bool isShoot = false;
    private PlayerAnimations target;
    private Collider2D[] zombies;
    Collider2D m_Collider;
    
    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimations>();
        m_Collider = GetComponent<Collider2D>();
        m_Collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(isShoot == true){
            Debug.Log("OnStay");
            zombies = collider.GetComponents<Collider2D>();
            Debug.Log(zombies);
            foreach(Collider2D zombie in zombies){
                // Debug.Log("Found:" + zombie.gameObject.name);
                // Debug.Log(zombie.gameObject.tag);
                if(zombie.gameObject.tag == "Enemy"){
                    var zombieAnim = zombie.GetComponent<ZombieAnimation>();
                    zombieAnim.Hurt();
                }
            }
            //target.Hurt();
            m_Collider.enabled = false;
            isShoot = false;
        }
    
    }

    private void OnTriggerStay2D(Collider2D collider)
    {

        if(isShoot == true){
            Debug.Log("OnStay");
            zombies = collider.GetComponents<Collider2D>();
            Debug.Log(zombies);
            foreach(Collider2D zombie in zombies){
                // Debug.Log("Found:" + zombie.gameObject.name);
                // Debug.Log(zombie.gameObject.tag);
                if(zombie.gameObject.tag == "Enemy"){
                    var zombieAnim = zombie.GetComponent<ZombieAnimation>();
                    zombieAnim.Hurt();
                }
            }
            //target.Hurt();
            m_Collider.enabled = false;
            isShoot = false;
        }
    }
    

    public void Shooting() {
        m_Collider.enabled = true;
        isShoot = true;
    }

    


}
