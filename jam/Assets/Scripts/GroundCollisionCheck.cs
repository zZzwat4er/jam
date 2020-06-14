using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    
    public bool IsGrounded()
    {
        //проверка на касание одной из половин
        //подробнее здесь: https://www.youtube.com/watch?v=c3iEl5AwUF8
        BoxCollider2D box = transform.GetComponent<BoxCollider2D>();
        RaycastHit2D hit= Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, box.bounds.extents.y, _mask);
        return hit.collider != null;
    }
}
