
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Move : MonoBehaviour
{
    public Text skorText;
    public int skor;
    private Animator anim;
    public Button right;
    public Button left;
    public Button jump;
    public float moveSpeed;
    private CharacterController controller;
    float xLocate;
    public LayerMask ground;
    public Transform groundChecker,groundChecker2;
    private float gravity = 9f;
    private Vector3 gravNew;
    private bool isGrounded,isgrounded2;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        skor = 0;
        xLocate = 0;
        moveSpeed = 1.3f;
        controller = GetComponent<CharacterController>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "snow")
        {
            skor += 1;
            Destroy(other);
           
        }


    }

    private void jb()
    {
        if (isGrounded)
        {
            gravNew.y = Mathf.Sqrt(0.25f * +2f * gravity / 14000);
        }
       
    }

    private void lb()
    {
        anim.SetBool("rigth", false);
        anim.SetBool("left", true);
        xLocate = -1f;
     
    }
    private void rb()
    {
        anim.SetBool("left", false);
        anim.SetBool("rigth", true);
        xLocate = 1f;
    }

    private void Update()
    {
        print(skor);
        
        skorText.text = skor.ToString();
        
        isGrounded = Physics.CheckSphere(groundChecker.position, 0.20f, ground) || Physics.CheckSphere(groundChecker2.position, 0.2f, ground);
        if (!isGrounded)
        {
            gravNew.y -= gravity * Time.deltaTime / 150;

        }

        jump.onClick.AddListener(jb);
        right.onClick.AddListener(rb);
        left.onClick.AddListener(lb);
       
        controller.Move(moveSpeed * Time.deltaTime * xLocate * transform.right);
        controller.Move(gravNew);
    }
    
    
}
