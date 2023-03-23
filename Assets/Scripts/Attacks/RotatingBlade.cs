using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class RotatingBlade : MonoBehaviour
{
    [HorizontalGroup("Split", Width = 50), HideLabel, PreviewField(50)]
    public Texture2D Icon;
    
    [VerticalGroup("Split/Properties")]
    public float rotationSpeed = 10f;
    [VerticalGroup("Split/Properties")]
    public float rotateAroundSpeed = 50f;
    [VerticalGroup("Split/Properties")]
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
