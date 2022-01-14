using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar; 
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0){
            Debug.Log("You Died");

            var target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimations>();
            
            if(!isDead){
                target.Dead();
                isDead = true;
            }

            if(target.isFinishedDying()){
                StartCoroutine(DeathWait());
            }
        }
        // if player get hurt, take damage
    }

    IEnumerator DeathWait(){
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(0);
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

    }
}
