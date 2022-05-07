using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scenechange_Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("maingame"); 
    }

    IEnumerator maingame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Home");
    }

}
