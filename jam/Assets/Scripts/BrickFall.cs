using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrickFall : MonoBehaviour
{
    private GameObject blockCreator;

    public float speed = 10f;

    private void OnEnable()
    {
        blockCreator = GameObject.FindWithTag("blockCreator");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        blockCreator.GetComponent<CreateBlock>().enabled = true;
        blockCreator.GetComponent<CreateBlock>().enabled = false;
        Destroy(gameObject.GetComponent<BrickFall>());
    }

    private void FixedUpdate()
    {
        gameObject.transform.parent.transform.position += Vector3.down * (Time.deltaTime * speed);
    }
}
