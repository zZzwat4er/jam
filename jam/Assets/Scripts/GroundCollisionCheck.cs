using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionCheck : MonoBehaviour
{
    private BoxCollider2D parantCol;
    [SerializeField] private LayerMask _mask;

        private void Start()
    {
        parantCol = gameObject.transform.parent.GetComponent<BoxCollider2D>();
    }

  

    public bool IsGrounded()
    {
        BoxCollider2D box = transform.GetComponent<BoxCollider2D>();
        RaycastHit2D hit= Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, box.bounds.extents.y, _mask);
        return hit.collider != null;
    }
}
