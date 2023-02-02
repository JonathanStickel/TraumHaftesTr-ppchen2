using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public string LevelName;
    public string CreditName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Level()
    {
        SceneManager.LoadScene(LevelName);
    }
   
    public void Credits()
    {
        SceneManager.LoadScene(CreditName);
    }
}
