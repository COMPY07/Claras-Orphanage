using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ClaraMove : MonoBehaviour
{

    [SerializeField] private GameObject Clara;
    /*
     * 필요한 변수 정리
     * speed -> 이동할때 한번 이동할
     * attackRange -> 공격 범위
     * 
     * 시작하기 앞서서 필요한 method 정리
     *
     * move() -> 클라라가 이동하는 함수
     *      getMoveDir() -> 클라라가 이동해야될 방향을 알려주는 함수
     *      getRange() -> 클라라가 이동이 가능한 범위를 가져오는 함수(각 맵이 다 연결되어 있어서 이동에 있어 범위를 플레이어 쪽으로 정해주는 것이 중요)
     * attack() -> 클라라가 플레이어를 공격하는 함수
     *      isPlayerInRange() -> 플레이어가 클라라의 공격 거리 안에 들어있는지 체크하는 함수
     * interaction() -> 클라라가 문, 숨은 곳 들쳐보기 등등의 행동을 취할 것인지를 판단하고 실행에 옮기는 함수
     *      isAble2Interaction() -> 클라라가 상호 작용이 가능한 오브젝트에 거리에 맞게 있는지를 확인하는 함수
     *      
     *      
     */
    
    [SerializeField] private float speed;
    [SerializeField] private float attackRange;
    [SerializeField] private float soundRange;
    
    private Vector3 dir;

    private float moveTime;

    private void Start()
    {
        dir = Vector3.zero;
    }

    private void Update() {
        move();
        attack();
        interaction();
    }

    void move() {
        if (moveTime <= 0) { moveSetup(); }

        moveTime += Time.deltaTime;
        this.gameObject.transform.Translate(dir * speed);
        
    }
    
    // region move sub methods
    
    void moveSetup()
    {
        moveTime = Random.Range(1, 7);
        
    }

    void movePlace(Vector2 position){
        
    }
    
    // endregion move sub methods
    
    
    // region getter methods
    public Vector3 getMoveDir() { return dir; }

    Vector2 getRange() { return Vector2.zero; }
    
    // endregion getter methods
    
    void attack()
    {
        if (!isPlayerInRange()) return;
    }

    bool isPlayerInRange()
    {
        

        return false;
    }


    void interaction()
    {
    }


}
