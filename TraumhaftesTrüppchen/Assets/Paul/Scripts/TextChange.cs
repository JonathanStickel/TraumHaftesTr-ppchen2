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
        yield return new WaitForSeconds(5);
        text.text = "Get close to an Object and press Leftclick to drag it";
        yield return new WaitForSeconds(5);
        text.text = "Thorns can kill you if you step on them";
        yield return new WaitForSeconds(5);
        text.text = "When you die your corpse will remain as a solid object";
        yield return new WaitForSeconds(5);
        text.text = "Press R to reset the Level";

    }
}
