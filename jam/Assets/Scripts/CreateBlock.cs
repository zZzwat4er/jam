using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{
    public GameObject brick; // перфаб с кирпичем
    // при включении скрипта спавнится кирпич
    private void OnEnable()
    {
        var curBrick = Instantiate(brick) as GameObject;
        curBrick.transform.position = gameObject.transform.position;
    }
}
