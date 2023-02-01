using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkDestroy : MonoBehaviour
{
    public TreeFall treeFall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            treeFall.isFalling = true;
        }
    }
}
