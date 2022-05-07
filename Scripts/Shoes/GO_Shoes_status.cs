using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GO_Shoes_status : MonoBehaviour
{
    
    ShoesButton ShoesButton;
    //shoes‘¤

    public void CheckShoes()
    {
        ShoesButton = this.GetComponent<ShoesButton>();
        Gamemanager_Shoesstatus.GSShoesnum = Shoesbox.GetShoescase()[ShoesButton.GSnum-1];
        SceneManager.LoadScene("Shoes_status");
    }
}
