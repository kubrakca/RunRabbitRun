using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class PlayerHealth : MonoBehaviour
{
    public float healthAmount=100f;
 
    public Image healthBar;
    private SpriteRenderer spriteRenderer;
    string currentSceneName;
    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentSceneName=SceneManager.GetActiveScene().name;

    }

    
    void Update()
    {
        if (healthAmount <= 0)
        {
            SceneManager.LoadScene(currentSceneName);
        }
        
    }

    public void TakeDamage(float Damage)
    {
        healthAmount-=Damage;
        healthBar.fillAmount = healthAmount/100f;
        Debug.Log(healthAmount);
    }
    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount=Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount/100f;
        Debug.Log(healthAmount);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Collision Calisti");
            TakeDamage(20);
        }
        else if (collision.gameObject.CompareTag("Apple"))
        {
            Heal(5);
            spriteRenderer.DOColor(Color.green, 0.5f).OnComplete(() =>
            {
                spriteRenderer.DOColor(Color.white, 0.5f);
            });
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Cherry"))
        {
            Heal(10);
            spriteRenderer.DOColor(Color.red, 0.5f).OnComplete(() =>
            {
                spriteRenderer.DOColor(Color.white, 0.5f);
            });
            Destroy(collision.gameObject);
        }


    }
    
}
