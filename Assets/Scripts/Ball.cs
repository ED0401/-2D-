using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 15.0f;
    public float maxSpeed = 50.0f;

    private Vector2 moveDirection;

    Rigidbody2D rigid;
   
    void Start()
    {
        Initializing();
    }

    void Update()
    {
        AccelASetting();
        DestroyEvent();
    }

    void FixedUpdate()
    {
        DirectionSpeedUpdate();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag == "Block")
        {
            Debug.Log("Block Hit!!");
            moveDirection = new Vector2(moveDirection.x, -moveDirection.y);

        }
        else if(other.gameObject.tag == "Racket")
        {
            float factor = FactorX(other.transform.position, transform.position, other.collider.bounds.size.x);
            Vector2 dir = new Vector2(factor, 1).normalized;
            moveDirection = dir;
            Debug.Log("Racket Hit!!");
        }
        else if(other.gameObject.tag == "Border")
        {
            if (other.gameObject.name.Contains("Top"))
            {
                moveDirection = new Vector2(moveDirection.x, -moveDirection.y);
            }
            else if(other.gameObject.name.Contains("Right") || other.gameObject.name.Contains("Left"))
            {
                moveDirection = new Vector2(-moveDirection.x, moveDirection.y);
            }
            Debug.Log("Border Hit!!");
        }
    }

    float FactorX(Vector2 racketPos,Vector2 ballPos,float width)
    {
        return (ballPos.x - racketPos.x / width);
    }

    


    void DirectionSpeedUpdate()
    {
        rigid.velocity = moveDirection * speed;
    }
    //初始化
    void Initializing()
    {
        rigid = GetComponent<Rigidbody2D>();
        moveDirection = new Vector2(1, 1);
        rigid.velocity = moveDirection * speed;
    }
    //加速設定
    void AccelASetting()
    {
        speed += Time.deltaTime / 5;
        if (speed >= maxSpeed)
            speed = maxSpeed;
    }

    void DestroyEvent()
    {
        if (transform.position.y <= -6.0f)
            Destroy(gameObject);
    }
}
