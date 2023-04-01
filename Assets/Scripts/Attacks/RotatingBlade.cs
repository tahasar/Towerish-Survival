using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBlade : MonoBehaviour
{
    public Texture2D Icon;
    
    public float rotationSpeed = 10f;
    public float rotateAroundSpeed = 50f;
    public float damage = 50;
    
    public GameObject rotateAround;

    private void Start()
    {
        rotateAround = GameObject.FindGameObjectWithTag("RotatingBlade");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0,0,rotationSpeed);
        transform.RotateAround(rotateAround.transform.position, Vector3.forward, rotateAroundSpeed * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        enemy.TakeDamage(damage);
    }
}
