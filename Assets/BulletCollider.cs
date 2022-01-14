using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletCollider : MonoBehaviour
{
    bool isShoot = false;
    private PlayerAnimations target;
    private Collider2D[] zombies;
    public List<GameObject> TouchingObjects;
    BoxCollider2D m_Collider;
    private int currentWpn;
    
    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimations>();
        m_Collider = GetComponent<BoxCollider2D>();
        m_Collider.enabled = true;
        TouchingObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (!TouchingObjects.Contains(collider.gameObject))
        TouchingObjects.Add(collider.gameObject);

        if(isShoot == true){

            TouchingObjects.RemoveAll(obj => obj.tag != "Enemy");

            if(currentWpn == 3){
                for(int i = 0; i < TouchingObjects.Count; i++){
                    var zombieAnim = TouchingObjects[i].GetComponent<ZombieAnimation>();
                    zombieAnim.Hurt();                
                }
            } else {

                var zombieAnim = TouchingObjects.LastOrDefault().GetComponent<ZombieAnimation>();
                zombieAnim.Hurt();    
            }

            isShoot = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (!TouchingObjects.Contains(collider.gameObject))
        TouchingObjects.Add(collider.gameObject);

        if(isShoot == true){

            TouchingObjects.RemoveAll(obj => obj.tag != "Enemy");


            if(currentWpn == 3){
                for(int i = 0; i < TouchingObjects.Count; i++){
                    var zombieAnim = TouchingObjects[i].GetComponent<ZombieAnimation>();
                    zombieAnim.Hurt();                
                }
            } else {

                var zombieAnim = TouchingObjects.LastOrDefault().GetComponent<ZombieAnimation>();
                zombieAnim.Hurt();    
            }

            isShoot = false;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision) {
        if (TouchingObjects.Contains(collision.gameObject))
        TouchingObjects.Remove(collision.gameObject);
    }


    public void Shooting(int weaponIDX) {
        currentWpn = weaponIDX;

        if(weaponIDX == 0){
            //Debug.Log(m_Collider.size.x);
            m_Collider.size = new Vector2(3f,3f);
        }
        if(weaponIDX == 1 || weaponIDX == 2){
            m_Collider.size = new Vector2(10f,1f);
        }
        if(weaponIDX == 3){
            m_Collider.size = new Vector2(5f,1f);
        }

        //m_Collider.enabled = true;
        isShoot = true;
    }

    


}
