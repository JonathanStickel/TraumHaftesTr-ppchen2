using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFall : MonoBehaviour
{
    public bool isFalling;
    public bool hasPlayed;
    public GameObject leaves;
    public GameObject standingTree;

    public AudioSource fallSound;
    private void Start()
    {
    }
    void Update()
    {
        if(isFalling)
        {
            gameObject.isStatic = false;
            if (!fallSound.isPlaying && !hasPlayed)
            {
                hasPlayed = true;
                fallSound.Play();
            }
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            leaves.SetActive(true);
            standingTree.SetActive(false);
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
