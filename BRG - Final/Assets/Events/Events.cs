using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Events
{
    public static UnityEvent gameOver = new UnityEvent();
    public static UnityEvent instantiateTopping = new UnityEvent();
    public static UnityEvent increaseScore = new UnityEvent();

}
