using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    public GameObject corpsePrefab;
    public GameObject upgradePrefab;
    public LayerMask deathLayer;
    public Vector3 startpos;
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
            GameObject corpse=Instantiate(corpsePrefab);
            corpse.transform.position = collision.gameObject.transform.position;
            // GameObject upgrade = Instantiate(upgradePrefab);
            // 
            // upgrade.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0);
            collision.gameObject.transform.position = startpos;
          //  Collider2D[] deathInRange = Physics2D.OverlapCircleAll(transform.position, 3, deathLayer);
          //  for (int i = 0; i < deathInRange.Length; i++)
          //  {
          //
          //      Destroy(deathInRange[i].gameObject);
          //  }

        }
    }
   
}


