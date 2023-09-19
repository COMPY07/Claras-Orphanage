using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    [Header("Player 움직")]
    private Rigidbody2D rigid;
    private Animator animator;
    public float moveSpeed = 5.0f;

    [Header("Player 상태")]
    // [HideInInspector] public bool isLive;
    // [HideInInspector] public bool isHide;
    public bool isLive;
    public bool isHide;
    private bool canHide, canPickup, canUseStair, canUseDoor, ending;

    [Header("현재 사용할 때 타고갈 객체")]
    private Stair stair;
    private ItemInfo pickUpItem;
    private Door door;
    
    [Header("그 외")]
    [HideInInspector] public bool isWalk;

    private GameObject mainCamera;
    private GameObject hidePanel;

    // public float HeartSoundRange;
    
    
    [SerializeField] private AudioSource audioSoure;

    [SerializeField] public  Inventory inventory;


    [SerializeField] public bool isRoom;

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
        isRoom = false;
        ending = false;
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
            MoveCamera();
            // HeartBeat
            //HeartBeat();
            Pickup();
            UseStair();
            UseDoor();
        }
    }

    void MoveCamera() {
        if (5.0f < rigid.position.x && rigid.position.x < 115.0f) {
            mainCamera.transform.position = new Vector3(rigid.position.x,
                rigid.position.y + 3.0f, mainCamera.transform.position.z);
        }else if (GameManager.RoomManager.GetCurrentRoom() != null) {
            if (GameManager.RoomManager.GetRoomsPos().x - 15 < rigid.position.x &&
                GameManager.RoomManager.GetRoomsPos().x + 15 > rigid.position.x) {
                mainCamera.transform.position = new Vector3(rigid.position.x,
                    rigid.position.y + 3.0f, mainCamera.transform.position.z);
            }
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

        this.gameObject.transform.GetComponent<SpriteRenderer>().enabled = !isHide;
    }
    
    public void Dead() {
        isLive = false;
        SceneManager.LoadScene("EndScene");

    }

    private void Pickup() {
        if (!canPickup) return;
        if (Input.GetKeyDown(KeyCode.F)) {
            // Debug.Log("줍기");
            inventory.Add(pickUpItem);
            // pickUpItem.Use();
        }
        
    }
 

    // region UseMethods
    void UseStair() { if (canUseStair && Input.GetKeyDown(KeyCode.F)) { this.gameObject.transform.position = stair.GetNext(); } }

    void UseDoor()
    {
        if (Input.GetKeyDown(KeyCode.F) && canUseDoor)
        {
            Vector3 a = door.Use();
            if (!a.Equals(Vector3.zero))
            {
                this.gameObject.transform.position = a;
            

                isRoom = !isRoom;
            }
        }
    }

    // endregion UseMethods
    
    
    
    
    
    // region TriggerMethods
    void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.tag) {
            case "HideObject": 
                canHide = true;
                break;
            case "Item": 
                canPickup = true;
                pickUpItem = collider.gameObject.GetComponent<ItemInfo>();
                if(pickUpItem == null) Debug.LogError("Incorrectly Registered Item");
                break; 
            case "Stair":
                canUseStair = true;
                stair = collider.gameObject.GetComponent<Stair>();
                break;
            case "Door":
            case "endBox":
                canUseDoor = true;
                door = collider.gameObject.GetComponent<Door>();
                break;
                
            case "Clara":
                if(!isHide) Dead();
                break;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        switch (collider.tag) {
            case "HideObject": 
                canHide = false;
                break;
            case "Item":
                canPickup = false;
                break;
            case "Stair":
                canUseStair = false;
                break;
            case "Door":
                canUseDoor = false;
                break;
        }

        // Debug.Log("can't hide");
    }
    
    // endregion TriggerMethods


}
