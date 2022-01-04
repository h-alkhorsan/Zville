using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    private Transform target;
    private int spawnSide;
    public GameObject zombie;
    public GameObject hole;
    public float spawnRate;
    public int rangeClose;
    public int rangeFar;
    private bool spawning = false;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
        Debug.Log(spawnDisplacement);
        Instantiate(zombie, target.position + new Vector3(spawnDisplacement,-0.5f,0), Quaternion.identity);
        var newHole = Instantiate(hole, target.position + new Vector3(spawnDisplacement,0,0), Quaternion.identity);
        Destroy(newHole,2);
        spawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!spawning){
            int[] choices = new int[] {-1, 1};
            spawnSide  = choices[Random.Range(0, choices.Length)];
            spawning = true;
            DoDelayAction(spawnRate);
        }
    }
}
