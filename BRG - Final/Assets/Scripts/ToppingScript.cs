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
        float x = transform.position.x + Random.Range(10, 16);
        float y = transform.position.y + 0.46f;

        NextTopping = Instantiate(NewToppingPrefab, new Vector2(x, y), Quaternion.identity) as GameObject;
        NextTopping.GetComponent<ToppingScript>().NewToppingPrefab = NewToppingPrefab;
        RandomNextToppingSprite();
    }

    public void RandomNextToppingSprite()
    {
        int nextToppingSpriteRandom = Random.Range(1, 5);
        switch (nextToppingSpriteRandom)
        {
            case 1:
                NextTopping.GetComponent<SpriteRenderer>().sprite = ToppingSprites[0];
                break;

            case 2:
                NextTopping.GetComponent<SpriteRenderer>().sprite = ToppingSprites[1];
                break;

            case 3:
                NextTopping.GetComponent<SpriteRenderer>().sprite = ToppingSprites[2];
                break;

            case 4:
                NextTopping.GetComponent<SpriteRenderer>().sprite = ToppingSprites[3];
                break;
        }
    }

}
