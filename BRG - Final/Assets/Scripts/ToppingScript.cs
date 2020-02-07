using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingScript : MonoBehaviour
{
    public float speed;
    private bool partOfBurger;
    public GameObject NewToppingPrefab;
    private GameObject NextTopping;
    public Sprite[] ToppingSprites;

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
            InstantiateTopping();
            //float newToppingY = gameObject.transform.position.y + 0.35f;
            //ManagerSC.instance.InstantiateTopping(newToppingY);
            //ManagerSC.instance.RandomNextToppingSprite();
        }
    }

    private void BecomePartOfBurger() 
    {
        partOfBurger = true;
        gameObject.AddComponent<Rigidbody2D>();
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        gameObject.transform.SetParent(GameObject.Find("UpperBun").transform);
        //ManagerSC.instance.IncreaseScore();
    }

    private void InstantiateTopping()
    {
        //float x = GameObject.Find("UpperBun").transform.position.x + Random.Range(10, 16);
        //float y = newToppingY;
        float x = transform.position.x + Random.Range(10, 16);
        float y = transform.position.y + 0.46f;

        NextTopping = Instantiate(NewToppingPrefab, new Vector2(x, y), Quaternion.identity) as GameObject;
        NextTopping.GetComponent<ToppingScript>().NewToppingPrefab = NewToppingPrefab;
    }

}
