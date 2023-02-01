using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCollider : MonoBehaviour
{
    public bool isRight;
    [SerializeField]
    private bool canPush;
    public PlayerMov player;

    private GameObject obj;
    private Transform pushPos;
    void Update()
    {
        if (canPush && Input.GetMouseButton(0))
        {
            Debug.Log("Test");
            player.isPushing = true;
            obj.transform.SetParent(player.transform);
        }
        else if (!Input.GetMouseButton(0))
        {
            player.isPushing = false;
            if (obj != null)
                obj.transform.parent = null;
        }

    }
    public float horDistanceToObj;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Pushable"))
        {
            obj = collision.gameObject;
            horDistanceToObj = player.transform.position.x + Vector2.Distance(player.transform.position, obj.transform.position);
            canPush = true;
            Debug.Log(Vector2.Distance(player.transform.position, obj.transform.position));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pushable"))
        {
            canPush = false;
        }
    }
}
