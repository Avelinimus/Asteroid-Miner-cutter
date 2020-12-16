using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{
    public float exploisionForce = 10;
    public bool isExplose = false;

    public GameObject explose;
    List<Rigidbody> caughtRigidbodies = new List<Rigidbody>();

    public void DestroyTNT()
    {
        for (int i = 0; i < caughtRigidbodies.Count; i++)
        {
            caughtRigidbodies[i].AddForce(-transform.position -(caughtRigidbodies[i].transform.position) * -exploisionForce * Time.deltaTime, ForceMode.Impulse);
        }
        Instantiate(explose, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.GetComponent<Rigidbody>())
        {
           //Add Rigidbody
           caughtRigidbodies.Add(collider.GetComponent<Rigidbody>());
           print(collider);
        }
    }
    private void Start()
    {
        
    }
    void Update()
    {
        if (isExplose) 
        {
            DestroyTNT();
        }
    }
}
