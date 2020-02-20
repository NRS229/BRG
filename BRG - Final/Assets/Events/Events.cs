using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Events
{
    public static UnityEvent gameOver = new UnityEvent();
    public static UnityEvent instantiateTopping = new UnityEvent();
    public static UnityEvent increaseScore = new UnityEvent();
    public static UnityEvent resume = new UnityEvent();
    public static UnityEvent pause = new UnityEvent();
    public static UnityEvent mainMenu = new UnityEvent();
    public static UnityEvent startGame = new UnityEvent();
    public static UnityEvent playAgain = new UnityEvent();

}
