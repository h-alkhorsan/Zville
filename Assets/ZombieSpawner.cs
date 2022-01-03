using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    private Transform target;
    public GameObject zombie;
    private bool once = false;
    public int spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Instantiate(zombie, target.position + new Vector3(5,0,0), Quaternion.identity);
        once = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
