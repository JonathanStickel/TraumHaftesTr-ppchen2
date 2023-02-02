using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(tutorial());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator tutorial() 
    {
        yield return new WaitForSeconds(2);
        text.text = "Get close to an Object and press Leftclick to drag it";

    }
}
