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
        if (collision.gameObject.tag == "Ground"){
            Events.gameOver.Invoke();
        }
    }

    private void BecomePartOfBurger() 
    {
        partOfBurger = true;
        gameObject.AddComponent<Rigidbody2D>();
        gameObject.transform.SetParent(GameObject.Find("UpperBun").transform);
    }    

}