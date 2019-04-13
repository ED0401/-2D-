using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    public float speed = 10.0f;

    public float limitedPosNX = -8.5f;
    public float limitedPosPX = 8.0f;
    
    
    void Update()
    {
        Vector2 r_Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(r_Pos.x, -4.5f);

        MoveLimited();
    }

    void MoveLimited()
    {
        if (transform.position.x >= limitedPosPX)
            transform.position = new Vector2(limitedPosPX, transform.position.y);
        else if (transform.position.x <= limitedPosNX)
            transform.position = new Vector2(limitedPosNX, transform.position.y);
    }
}
