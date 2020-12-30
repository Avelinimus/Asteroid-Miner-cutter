using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorAsteroids : MonoBehaviour
{
    public GameObject asteroid;
    public int count = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount < count) 
        {
            Instantiate(asteroid, new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), Random.Range(20f, 110f)), Quaternion.identity, transform);
        }
    }
}
