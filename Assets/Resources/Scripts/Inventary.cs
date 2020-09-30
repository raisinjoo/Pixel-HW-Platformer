using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventary : MonoBehaviour
{
    private void Awake() 
    {
        Instance = this;
    }
    public static Inventary Instance{get;set;}
    public int coins;

    public  void AddCoins()
    {
        coins++;
    }
}
