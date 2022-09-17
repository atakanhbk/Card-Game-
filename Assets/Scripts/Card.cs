using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card
{
    public int id;
    public string cardName;
    public int speed;
    public int durability;
    public string cardDescription;
    
    public Card()
    {

    }

    public Card(int Id,string CardName,int Speed,int Durability,string CardDescription)
    {
        id = Id;
        cardName = CardName;
        speed = Speed;
        durability = Durability;
        cardDescription = CardDescription;

    }
}
