using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFall : MonoBehaviour
{
    public bool isFalling;
    public GameObject leaves;
    public GameObject standingTree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFalling)
        {
            gameObject.isStatic = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            leaves.SetActive(true);
            standingTree.SetActive(false);
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
