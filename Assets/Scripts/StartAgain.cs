using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAgain : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

}
