using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerCollide : MonoBehaviour
{
    public Animator deathAnimator;
    public GameObject corpsePrefab;
    public GameObject upgradePrefab;
    public GameObject deathAnimation;
    public LayerMask deathLayer;
    public Vector3 startpos;
    public bool drowned = false;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(drowned)
        {
            drowned = false;
            Player.transform.position = startpos;
            StartCoroutine(Death(GetComponent<Collision2D>()));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Death(collision));
            collision.gameObject.transform.position = startpos;
            // GameObject upgrade = Instantiate(upgradePrefab);
            // 
            // upgrade.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0);
          //  Collider2D[] deathInRange = Physics2D.OverlapCircleAll(transform.position, 3, deathLayer);
          //  for (int i = 0; i < deathInRange.Length; i++)
          //  {
          //
          //      Destroy(deathInRange[i].gameObject);
          //  }

        }
    }
    public float deathAnimationTime  = 1.3f;
    IEnumerator Death(Collision2D coll)
    {
        Vector3 pos = coll.gameObject.transform.position;
        Instantiate(deathAnimation, pos, Quaternion.identity);
        yield return new WaitForSeconds(deathAnimationTime);
        GameObject corpse = Instantiate(corpsePrefab);
        corpse.transform.position = pos;
    }
}



