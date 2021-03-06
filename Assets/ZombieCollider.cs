using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCollider : MonoBehaviour
{
    bool isBite = false;
    private PlayerAnimations target;
    Collider2D m_Collider;
    
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player")){
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimations>();
        }
        m_Collider = GetComponent<Collider2D>();
        m_Collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(isBite == true){
            m_Collider.enabled = false;
            var playerHealthBar = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<PlayerHealth>(); 
            target.Hurt();
            playerHealthBar.TakeDamage(10);
            isBite = false;
        }
    
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(isBite == true){
            //Debug.Log("Bitten");
            m_Collider.enabled = false;
            target.Hurt();
            isBite = false;
        }
    }

    public void Biting() {
        m_Collider.enabled = true;
        isBite = true;
    }




}
