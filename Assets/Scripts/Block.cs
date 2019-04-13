using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public enum ColorType
    {
        Blue,
        Green,
        Purple,
        Red,
        Yellow
    }

    public ColorType type = ColorType.Blue;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(type == ColorType.Blue)
            {

            }
            else if(type == ColorType.Green)
            {

            }
            else if(type == ColorType.Purple)
            {

            }
            else if(type == ColorType.Red)
            {

            }
            else if(type == ColorType.Yellow)
            {

            }
            ScoreDisplay.instance.Add(100);
            Destroy(gameObject);

        }
    }




}
