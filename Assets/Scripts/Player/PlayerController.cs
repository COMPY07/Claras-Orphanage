using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator animator;
    public float moveSpeed = 5.0f;

    [HideInInspector] public bool isLive;
    [HideInInspector] public bool isHide;
    private bool canHide;

    [HideInInspector] public bool isWalk;

    private GameObject mainCamera;
    private GameObject hidePanel;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        mainCamera = GameObject.FindWithTag("MainCamera");
        hidePanel = GameObject.Find("HidePanel");
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        isLive = true;
        isHide = false;
        canHide = false;

        isWalk = false;
    }

    void Update()
    {
        if (isLive)
        {
            //move player
            float xInput = Input.GetAxisRaw("Horizontal");
            float xSpeed = xInput * moveSpeed;

            if (xInput != 0)
            {
                isWalk = true;
                transform.localScale = new Vector3(xInput * 3, 3, 0);
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }

            if (!isHide)
            {
                rigid.velocity = new Vector2(xSpeed, 0.0f);
            }

            //hide player
            if (canHide && Input.GetKey(KeyCode.S)) {
                rigid.velocity = new Vector2(0.0f, 0.0f);
                isHide = true;
                hidePanel.SetActive(true);
                animator.SetBool("isSiting", true);
            }
            else
            {
                isHide = false;
                hidePanel.SetActive(false);
                animator.SetBool("isSiting", false);
            }

            //move camera
            if (-5.0f < rigid.position.x && rigid.position.x < 5.0f)
            {
                mainCamera.transform.position = new Vector3(rigid.position.x, rigid.position.y + 2.0f, mainCamera.transform.position.z);
            }

            //
        }
    }

    public void Dead()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "HideObject") canHide = true;
        Debug.Log("can hide");
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "HideObject") canHide = false;
        Debug.Log("can't hide");
    }
}
