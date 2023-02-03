using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PostProcess;
    public GameObject BlackScreen;
    public float startSoundTime;

    public AudioSource ambient;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        StartCoroutine(StartBlendIn());
    }

    IEnumerator StartBlendIn()
    {

        yield return new WaitForSeconds(startSoundTime);
        PostProcess.SetActive(true);
        BlackScreen.SetActive(false);
        ambient.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
