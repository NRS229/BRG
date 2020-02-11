using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingScript : MonoBehaviour
{
    public float speed;
    private bool partOfBurger;

    void FixedUpdate()
    {
        if(!partOfBurger)
        {
            transform.Translate(-speed, 0, 0);
        }
        else
        {
            gameObject.name = "Topping";
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "UpperBun" & !partOfBurger)
        {
            BecomePartOfBurger();
        }
    }

    private void BecomePartOfBurger() 
    {
        partOfBurger = true;
        gameObject.AddComponent<Rigidbody2D>();
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        gameObject.transform.SetParent(GameObject.Find("UpperBun").transform);
    }    

}