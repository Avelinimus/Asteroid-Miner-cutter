﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float rotateX, rotateY, rotateZ;
    public bool isRotate = true;

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            Destroy();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rotateX = transform.localRotation.x;
        rotateY = transform.localRotation.y;
        rotateZ = transform.localRotation.z;
        if (transform.childCount > 0)
        {
            InitScaleAsteroid();
            transform.localScale = new Vector3(1f, 1f, 1f);
            
        }
        InitRotateAsteroid();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)
        {
            ScaleAsteroid();
            if (isRotate)
            {
                RotateAsteroid();
            }
        }
    }


    
    public void Destroy() 
    {
        gameObject.GetComponent<MeshFilter>().mesh = new Mesh();
        gameObject.GetComponent<MeshCollider>().enabled = false;
        for(int i = 0; i < transform.childCount; i++) 
        {
            transform.GetChild(i).GetComponent<MeshCollider>().enabled = true;
            transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
            transform.GetChild(i).GetComponent<Asteroid>().enabled = true;
        }
        isRotate = false;
    }

    // Init and process scale
    private float[] axisScale = new float[3];
    private void InitScaleAsteroid()
    {
        for (int i = 0; i < 3; i++)
        {
            axisScale[i] = Random.Range(0.8f, 4f);
        }
    }
    private void ScaleAsteroid()
    {
        float x, y, z;
        x = 0; y = 0; z = 0;
        x = axisScale[0];
        y = axisScale[1];
        z = axisScale[2];
        transform.localScale = new Vector3(x, y, z);
    }


    // Init and process movement
    private float[] axisRotate = new float[3];
    private void InitRotateAsteroid() {
        for (int i = 0; i < 3; i++)
        {
            axisRotate[i] = Random.Range(-0.2f, 0.2f)*0.0001f;
        }
    }
    private void RotateAsteroid() 
    {
        rotateX += axisRotate[0] * Time.deltaTime;
        rotateY += axisRotate[1] * Time.deltaTime;
        rotateZ += axisRotate[2] * Time.deltaTime;
        transform.Rotate(rotateX, rotateY, rotateZ);
    }
}
