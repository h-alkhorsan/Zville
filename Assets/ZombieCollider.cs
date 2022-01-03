using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCollider : MonoBehaviour
{
    bool isBite = false;
    private PlayerAnimations target;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(isBite == true){
            isBite = false;
        }
    
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(isBite == true){
            Debug.Log("Bitten");
            target.Hurt();
            isBite = false;
        }
    }

    public void Biting() {
        isBite = true;
    }




}
