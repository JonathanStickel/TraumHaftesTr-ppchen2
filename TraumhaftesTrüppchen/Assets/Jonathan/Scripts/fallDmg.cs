using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallDmg : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.velocity.y < -27)
        {
            Debug.Log(transform.position);
        }
    }
}
