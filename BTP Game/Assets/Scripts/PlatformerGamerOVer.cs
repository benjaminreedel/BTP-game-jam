using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformerGamerOVer : MonoBehaviour
{
    
    void Update()
    {
        
        if (PlayerStats.Energy < 0) {
            SceneManager.LoadScene("GameOver");
        }
         
    }
}
