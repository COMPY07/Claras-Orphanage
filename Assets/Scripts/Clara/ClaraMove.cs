using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ClaraMove : MonoBehaviour
{
    [Header("???")]
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
    
    
    [Header("Stats")]
    [SerializeField] private float speed;
    [SerializeField] private float attackRange;
    [SerializeField] private float soundRange;
    [SerializeField] private float moveRange;

    private Vector3 dir;
    private bool heard, attacking;
    private float moveTime;

    
    [Header("왼쪽 맨 끝")]
    [SerializeField] private float left;
    [Header("오른쪽 맨 끝")]
    [SerializeField] private float right;

    private void Start() {
        setup();
    }

    void setup()
    {
        dir = Vector3.zero;
        moveTime = 0;
        heard = false;
        attacking = false;
    }

    private void Update() {
        move();
        attack();
        interaction();
    }

    void move() {
        if (!GameManager.Player.GetComponent<PlayerController>().isRoom &&
            getDistance() < 5.5f &&
            !GameManager.Player.GetComponent<PlayerController>().isHide)
        {
            // Debug.Log(GameManager.Player.GetComponent<PlayerController>().isRoom);
            if ((transform.position - GameManager.Player.transform.position).x > 0) dir = Vector3.left;
            else dir = Vector3.right;
        }
        else
        {
            if (moveTime <= 0) { moveSetup(); }

            moveTime -= Time.deltaTime;
            if ((transform.position + dir * speed * Time.deltaTime).x > right ||
                (transform.position + dir * speed * Time.deltaTime).x < left) dir *= -1;

            
        }
        if (dir == Vector3.left) this.gameObject.transform.localScale = new Vector3(-2, 2, 3);
        else this.gameObject.transform.localScale = new Vector3(2, 2, 3);
        this.gameObject.transform.Translate(dir * speed * Time.deltaTime);

    }
    
    // region move sub methods
    
    void moveSetup() {
        if (getDistance() - moveRange < 0)
        {
            dir = Random.Range(0, 2) == 0 ? Vector3.left : Vector3.right;
            moveTime = Random.Range(1f, 1.8f);
        }
        else {
            dir = GameManager.Player.transform.position.x - transform.position.x > 0 ? Vector3.right : Vector3.left;
            moveTime = Random.Range(0.5f, getDistance() / speed * Time.deltaTime);
        }
        // Debug.Log(dir+" "+moveTime);
        
        // min = 1, max = range랑 speed랑 현재 플레이어와의 거리로 고려한 식으로 바꿀거임
    }
    
    public void movePlace(Vector2 position) {
        dir = this.transform.position.x > position.x ? Vector3.left : Vector3.right;
        moveTime = getDistance(transform.position,  position) / (speed * Time.deltaTime);
        Invoke("whereAnimation", moveTime);
    }

    void whereAnimation() {
        // 애니메이션
    }
    // endregion move sub methods
    
    
    // region getter methods
    public Vector3 getMoveDir() { return dir; }

    public bool isClaraHear(Vector2 pos) { return getDistance(pos ,transform.position) <= soundRange; }

    float getDistance(Vector3 a, Vector3 b) { return Math.Abs(a.x - b.x); }
    float getDistance() { return Math.Abs(GameManager.Clara.transform.position.x - GameManager.Player.transform.position.x); }

    // endregion getter methods
    
    void attack() {
        if (!isPlayerInRange()) return;
        attacking = true;
        // animation
        
    }

    bool isPlayerInRange() {
        return getDistance() <= attackRange;
    }


    void interaction()
    {
        
    }


}
