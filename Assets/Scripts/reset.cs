using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class reset : MonoBehaviour
{
    private GameObject car;
    public Rigidbody carRb;
    private void Start()
    {
        car = GameObject.FindWithTag("Player");
        carRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector3(-4.26f, 0f, -13.09f);
            car.transform.rotation = Quaternion.identity;
            carRb.velocity = new Vector3(0f, 0f, 0f);
        }
    }
}