using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PinkCharPlayer : MonoBehaviour
{
    public float movespeed;
    private Rigidbody2D rbP;

    public float jumpforce;

    public Transform GroundCheck;
    public float GroundCheckRadius;
    public LayerMask GroundLayer;
    private bool IsGrounded;

    private SpriteRenderer sr;
    private Animator animator;

    private float horizontalInput = 0f;
    public Score coin;
    
    public AudioClip treasureSound;
    

    void Start()
    {
        rbP = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
        }
        else
        {
            horizontalInput = 0f;
        }

        rbP.velocity = new Vector2(horizontalInput * movespeed, rbP.velocity.y);

        // Z?plama için yukar? ok tu?unu kullan?yoruz
        if (Input.GetKeyDown(KeyCode.W))
        {
            rbP.velocity = new Vector2(rbP.velocity.x, jumpforce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin")){
            coin.coinCount++;
            coin.m_TextMeshPro.text=coin.coinCount.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Treasure"))
        {
            AudioSource.PlayClipAtPoint(treasureSound, transform.position);
            coin.coinCount=coin.coinCount+50;
            coin.m_TextMeshPro.text = coin.coinCount.ToString();
            Destroy(collision.gameObject);
        }
    }
    



}