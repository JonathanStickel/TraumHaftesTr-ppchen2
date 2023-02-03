using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drown : MonoBehaviour
{
    public List<GameObject> collidingFluids = new List<GameObject>();
    public PlayerCollide death;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Fluid"))
        {
            collidingFluids.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fluid"))
        {
            collidingFluids.Remove(collision.gameObject);
        }
    }

    public float maxFluids;
    public float fluids;
    private void Update()
    {
        for(int i = 0; i<collidingFluids.Count; i++)
        {
            fluids = i;
        }

        //Debug.Log(fluids);
        if (fluids >= maxFluids)
        {
            death.drowned = true;
            fluids = 0;
        }
        //Debug.Log("Playerdied by drowning")
        else
            fluids = 0;
    }
}
