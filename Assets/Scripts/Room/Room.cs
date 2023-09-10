using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    /*
     * String name -> 방의 이름
     * int id -> 방 번호
     * 2DSprite BGImg -> 뒤에 벽지
     */

    [SerializeField] private string name;
    [SerializeField] private int id;
    [SerializeField] private SpriteRenderer BGImgRenderer;
    [SerializeField] private Sprite BGImg;


    private Vector3 enterPos;

    [SerializeField] private Door connetedDoor;
    
    private void Start() {
        if (name == null || id == null || BGImg == null) {
            Debug.LogError("room 할당 오류 -> 기본 값으로 수정됩니다.(name = null, id = -1, BGImg = null)");
            name = "null";
            id = -1;
            BGImg = null;
        }

        name = this.gameObject.name;

        BGImgRenderer = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        BGImgRenderer.sprite = BGImg;
        BGImgRenderer.color = Color.white;
        BGImgRenderer.gameObject.transform.localScale = new Vector3(2.3f, 2.5f, 1);


        enterPos = new Vector3(-10, -2.5f, 0);
    }

    public Vector3 getEnterPos()
    {
        return enterPos;
    }

    public string GetName()
    {
        return name;
    }

    public int GetId() {
        return id;
        
    }

    public SpriteRenderer GetImgRenderer() {
        return BGImgRenderer;
    }
    
    public Sprite GetImg() {
        return BGImg;
    }
    

}
