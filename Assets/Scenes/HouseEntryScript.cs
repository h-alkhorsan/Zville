using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseEntryScript : MonoBehaviour
{

    public GameObject player;
    Vector3 playerVector;
    List<Vector3> entryPoints = new List<Vector3>();

    void Start()

    {

        foreach(GameObject entryPoint in GameObject.FindGameObjectsWithTag("Entry"))
        {
            entryPoints.Add(entryPoint.transform.position);
        }

    }

    void Update()

    {
        playerVector = player.transform.position;

        int range = 3;

        foreach(Vector3 entryVector in entryPoints)
        {
            if (Vector3.Distance(playerVector, entryVector) < range)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    //SwitchScene();
                    Debug.Log("Switch Scene");
                }
            }
        }

    }

    void SwitchScene()
    {
        SceneManager.LoadScene(sceneName: "Interior");
    }
}