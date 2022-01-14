using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletCollider : MonoBehaviour
{
    bool isShoot = false;
    private Transform target;
    private Collider2D[] zombies;
    public List<GameObject> TouchingObjects;
    BoxCollider2D m_Collider;
    private int currentWpn;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        m_Collider = GetComponent<BoxCollider2D>();
        m_Collider.enabled = true;
        TouchingObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

                var  Sortedlist = TouchingObjects.OrderBy(i => Mathf.Abs(i.transform.position.x - target.position.x));

                var zombieAnim = Sortedlist.FirstOrDefault().GetComponent<ZombieAnimation>();
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
        //-1.2
        //-4.3
        m_Collider.offset = new Vector2(-4.4f,0f);

        if(weaponIDX == 0){
            m_Collider.offset = new Vector2(-1.2f,0f);
            m_Collider.size = new Vector2(3f,3f);
        }
        if(weaponIDX == 1 || weaponIDX == 2){
            m_Collider.size = new Vector2(10f,1f);
        }
        if(weaponIDX == 3){
            m_Collider.offset = new Vector2(-3.16f,0f);
            m_Collider.size = new Vector2(5f,1f);
        }
        isShoot = true;

    }


    


}
