using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BrickMovement : MonoBehaviour
{
    private bool isActive;
    public GameObject point1;
    public GameObject point2;
    public float speed;
    
    // Start is called before the first frame update
    private GameObject targetPoint;
    private Vector3 lastVector;
    
    private void Start()
    {
        isActive = true;
        targetPoint = point1;
        lastVector = targetPoint.transform.position - gameObject.transform.position;
        lastVector = lastVector.normalized;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isActive)
        {
            Vector3 movementVector = targetPoint.transform.position - gameObject.transform.position;
            movementVector = movementVector.normalized;

            if (movementVector == Vector3.zero || movementVector != lastVector)
            {
                targetPoint = (targetPoint == point1) ? point2 : point1;
                lastVector = targetPoint.transform.position - gameObject.transform.position;
                lastVector = lastVector.normalized;
            }
            else
            {
                gameObject.transform.position += movementVector * (speed * Time.deltaTime);
                lastVector = movementVector;
            }
        }
    }

    public void Ping()
    {
        isActive = false;
        Debug.Log("brick was taped");
    }
}