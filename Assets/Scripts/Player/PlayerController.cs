using System;
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
    private bool canHide, canPickup, canUseStair;

    private Stair stair;
    
    private ItemInfo pickUpItem;
    [HideInInspector] public bool isWalk;

    private GameObject mainCamera;
    private GameObject hidePanel;

    public float HeartSoundRange;
    [SerializeField] private AudioSource audioSoure;

    [SerializeField] private Inventory inventory;
    

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        mainCamera = GameObject.FindWithTag("MainCamera");
        hidePanel = GameObject.FindWithTag("HidePanel");
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        isLive = true;
        isHide = false;
        canHide = false;
        isWalk = false;
        if(audioSoure != null) audioSoure.loop = true;
    }

    void Update() {
        if (isLive)
        {
            //move player
            move(Input.GetAxisRaw("Horizontal"));
            
            //hide player
            hide();

            //move camera
            if (-5.0f < rigid.position.x && rigid.position.x < 35.0f) {
                mainCamera.transform.position = new Vector3(rigid.position.x,
                    rigid.position.y + 3.0f, mainCamera.transform.position.z);
            }
            // HeartBeat
            //HeartBeat();
            Pickup();
            UseStair();
        }
    }

    void UseStair() {
        if (canUseStair && Input.GetKey(KeyCode.F)) {
            this.gameObject.transform.position = stair.GetNext();
        }
    }
    
    void move(float xInput) {
        if (xInput != 0) {
            isWalk = true;
            transform.localScale = new Vector3(xInput * 3, 3, 0);
            animator.SetBool("isWalking", true);
        }
        else { animator.SetBool("isWalking", false); }
        if (!isHide) { rigid.velocity = new Vector2(xInput * moveSpeed, rigid.velocity.y); }
    }

    void hide()
    {
        if (canHide && Input.GetKey(KeyCode.S)) {
            rigid.velocity = new Vector2(0.0f, 0.0f);
            isHide = true;
            // hidePanel.SetActive(true);
            animator.SetBool("isSiting", true);
        }
        else {
            isHide = false; 
            // hidePanel.SetActive(false);
            animator.SetBool("isSiting", false);
        }
    }
    
    /*void HeartBeat()
    {
        if (audioSoure != null) {
            audioSoure.volume = HeartSoundRange / GameManager.getDistance();
        }
    }*/
    public void Dead()
    {
        
    }

    private void Pickup() {
        if (!canPickup) return;
        if (Input.GetKey(KeyCode.F)) {
            // Debug.Log("줍기");
            inventory.Add(pickUpItem);
        }
        
    }
    

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "HideObject") canHide = true;
        if (collider.tag == "Item") {
            canPickup = true;
            pickUpItem = collider.gameObject.GetComponent<ItemInfo>();
            if(pickUpItem == null) Debug.LogError("Incorrectly Registered Item");
        }

        if (collider.tag == "Stair") {
            canUseStair = true;
            stair = collider.gameObject.GetComponent<Stair>();
        }
        // Debug.Log("can hide");
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.tag == "HideObject") canHide = false;
        if (collider.tag == "item") canPickup = false;
        if (collider.tag == "Stair") canUseStair = false;
        // Debug.Log("can't hide");
    }


}
