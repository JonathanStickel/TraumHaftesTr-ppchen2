using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           // collision.gameObject.GetComponent<PlayerMov>().enabled = false;
           // collision.gameObject.GetComponent<CamFollow>().enabled = false;
           // collision.gameObject.GetComponent<PlayerCollide>().enabled = false;
           // gameObject.GetComponent<Transform>().localScale.Set(1, 0.47f, 1);
            GameObject player=Instantiate(playerPrefab);
            player.transform.position = new Vector3(-8.16f, -1.42f, 0);

        }
    }
}
