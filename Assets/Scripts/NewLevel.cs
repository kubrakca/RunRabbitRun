using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LevelManager : MonoBehaviour
{
    public GameObject EndPanel;
    

    void Start()
    {
        
    }

    void Update()
    {
       
    }

    void InitializeLevel()
    {
        
    }

    void SpawnNextSection()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            SceneManager.LoadScene("Level2");
        }
        else if(collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
