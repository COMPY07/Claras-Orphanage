using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float moveSpeed = 5.0f;

    [HideInInspector] public bool isLive;
    [HideInInspector] public bool isHide;
    private bool canHide;

    private GameObject mainCamera;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    void Start()
    {
        isLive = true;
        isHide = false;
        canHide = false;
    }

    void Update()
    {
        if (isLive)
        {
            //move player
            if (!isHide)
            {
                float xInput = Input.GetAxis("Horizontal");
                float xSpeed = xInput * moveSpeed;

                Vector2 newVelocity = new Vector2(xSpeed, 0.0f);
                rigid.velocity = newVelocity;

            }

            //hide player
            if (canHide && !isHide)
            {
                Debug.Log("you can hide");

                if(Input.GetKeyDown(KeyCode.S)) isHide = true;
            }
            else if (canHide && isHide)
            {
                Debug.Log("you can go to out");

                if (Input.GetKeyDown(KeyCode.S)) isHide = false;
            }

            //move camera
            if (-5.0f < rigid.position.x && rigid.position.x < 5.0f)
            {
                mainCamera.transform.position = new Vector3(rigid.position.x, rigid.position.y + 1.0f, mainCamera.transform.position.z);
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
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "HideObject") canHide = false;
    }
}
