using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ZombieSpawner : MonoBehaviour
{
    private Transform target;
    private int spawnSide;
    public GameObject zombie;
    public GameObject hole;
    public float spawnRate;
    public float rangeClose;
    public float rangeFar;
    private bool spawning = false;
    public int level;
    private float spawnRateF = 3f;
    private float rangeCloseF = 5f;
    private float rangeFarF = 10f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spawnRateF = spawnRate;
        rangeCloseF = rangeClose;
        rangeFarF = rangeFar;
    }

    void DoDelayAction(float delayTime)
    {
        StartCoroutine(DelayAction(delayTime));
    }
    
    IEnumerator DelayAction(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);
        
        //Do the action after the delay time has finished.
        var spawnDisplacement = spawnSide*Random.Range(rangeClose,rangeFar);
        // Debug.Log(spawnDisplacement);
        Instantiate(zombie, target.position + new Vector3(spawnDisplacement,-0.5f,0), Quaternion.identity);
        var newHole = Instantiate(hole, target.position + new Vector3(spawnDisplacement,0,0), Quaternion.identity);
        Destroy(newHole,2);
        spawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player")){

        
        if(!spawning){
            int[] choices = new int[] {-1, 1};
            spawnSide  = choices[Random.Range(0, choices.Length)];
            spawning = true;
            DoDelayAction(spawnRate);
        }
        var currentPos = target.position.x;
        var levelSize = 27f;

        for(int i = 0; i < 9; i++){
            if(currentPos > levelSize*i){
                level = i;
            }
            

        }

        if(level != 0){
            spawnRate = spawnRateF - (2f/(9f-level));
            rangeClose = rangeCloseF - (3f/(9f-level));
            rangeFar = rangeFarF - (4f/(9f-level));

        }   

        if(currentPos > 246f){
            Debug.Log("Finished Game");
            SceneManager.LoadScene(0);
        }
        }






    }
}
