using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BrickMovement : MonoBehaviour
{
    private bool isActive;
    // точки по которым двигается кирпич
    public GameObject point1; 
    public GameObject point2;
    // скорость движения
    public float speed;
    
    // Start is called before the first frame update
    private GameObject targetPoint; //точка к котороый кирпич движется прямо сейчас
    private Vector3 lastVector; // прошлый вектор движения (нужен для смены напровления)
    
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
            // вычисляем вектор в напровлении которого нам надо двигаться и нормализуем его
            Vector3 movementVector = targetPoint.transform.position - gameObject.transform.position;
            movementVector = movementVector.normalized;
            // если мы на месте или ме перескочили необходимю точку то меняем targetPoint
            if (movementVector == Vector3.zero || movementVector != lastVector)
            {
                targetPoint = (targetPoint == point1) ? point2 : point1;
                lastVector = targetPoint.transform.position - gameObject.transform.position;
                lastVector = lastVector.normalized;
            }
            // иначе движемся к точке
            else
            {
                gameObject.transform.position += movementVector * (speed * Time.deltaTime);
                lastVector = movementVector;
            }
        }
    }
    
}