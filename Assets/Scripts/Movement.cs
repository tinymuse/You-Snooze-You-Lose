using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float floatSpeed;
    public float moveSpeed;
    private Animator m_Animator;
    public SpriteRenderer[] renderers;


    public void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
           
    }

    public void Update()
    {
        //player keeps moving up on their own at x rate
        //if player presses down, player moves down
        //particle effects of bubbles :)

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            
            var v3 = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            transform.Translate(moveSpeed * v3.normalized * Time.deltaTime);
        }
        else
        {
            m_Animator.SetBool("SwimDown", false);
            m_Animator.SetBool("SwimLeftRight", false);
            transform.Translate(Vector3.up * Time.deltaTime * floatSpeed);
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_Animator.SetBool("SwimDown", true);
        }
        else 
        {
            m_Animator.SetBool("SwimDown", false);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_Animator.SetBool("SwimUp", true);
        }
        else
        {
            m_Animator.SetBool("SwimUp", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {          


            m_Animator.SetBool("SwimLeftRight", true);
        }

        else
        {
            m_Animator.SetBool("SwimLeftRight", false);
        }

        FlipSprites();

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {

            m_Animator.SetBool("SwimDown", false);
            m_Animator.SetBool("SwimLeftRight", false);
            m_Animator.SetBool("SwimDiagonal", true);
        }

        else
        {
            m_Animator.SetBool("SwimDiagonal", false);
        }

        FlipSprites();


    }

    public void FlipSprites()
    {
        foreach (SpriteRenderer rend in renderers)
        {
            
            if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                transform.localScale = new Vector2(-1, -1);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                transform.localScale = new Vector2(1, -1);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
            }
            
        }
    }


        /*
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
                {
                transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
            }
            else
            { 
                transform.Translate(Vector3.up * Time.deltaTime * floatSpeed);
            }
        }*/


    }


