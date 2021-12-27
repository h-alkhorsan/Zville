using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float Length, StartPos;
    public GameObject cam;
    public float ParallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position.x;
        Length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - ParallaxEffect));
        float Distance = (cam.transform.position.x * ParallaxEffect);
        transform.position = new Vector3(StartPos + Distance, transform.position.y, transform.position.z);

        if (temp > StartPos + Length) StartPos += Length;
        else if (temp < StartPos - Length) StartPos -= Length;
    }
}
