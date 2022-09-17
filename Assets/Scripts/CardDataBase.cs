using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

     void Awake()
    {
        cardList.Add(new Card(0, "None", 0, 0, "None"));
        cardList.Add(new Card(1, "Elf", 20, 30, "It's Elf"));
        cardList.Add(new Card(2, "Dwarf", 10, 60, "It's Drawf"));
        cardList.Add(new Card(3, "Human", 15, 35, "It's Human"));
        cardList.Add(new Card(4, "Demon", 1, 20, "It's Demon"));
    }
}
