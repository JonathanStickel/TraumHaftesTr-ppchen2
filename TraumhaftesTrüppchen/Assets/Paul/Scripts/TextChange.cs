using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
    public Text text;
    public bool isNearSpikes;
    // Start is called before the first frame update
    void Start()
    {
        isNearSpikes = false;
        StartCoroutine(tutorial());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator tutorial() 
    {
        yield return new WaitForSeconds(2);
        text.text = "Get close to an object and press leftclick to drag it";
        // if (isNearSpikes == true)
        yield return new WaitForSeconds(8f);
            text.text = "Thorns can kill you if you step on them";
            yield return new WaitForSeconds(2);
            text.text = "If you die your corpse will remain ";
            yield return new WaitForSeconds(2);
            text.text = "You can use corpses as solid objects ";
        

    }
}
