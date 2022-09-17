using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public int id;
    public string cardName;
    public int speed;
    public int durability;
    public string cardDescription;

    public Text nameText;
    public Text speedText;
    public Text durabilityText;
    public Text descriptionText;

    public GameObject character;

    bool workForOnce = true;

    void Start()
    {
        thisCard[0] = CardDataBase.cardList[thisId];

     
    }

    

    // Update is called once per frame
    void Update()
    {
        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        speed = thisCard[0].speed;
        durability = thisCard[0].durability;
        cardDescription = thisCard[0].cardDescription;

        nameText.text = "" + cardName;
        speedText.text = "Speed =" + speed;
        durabilityText.text = "Durability = " + durability;
        descriptionText.text = "" + cardDescription;


        if (workForOnce)
        {
            if (character.gameObject.name == "Human")
            {
                character.GetComponent<HumanController>().humanSpeed = speed;
                character.GetComponent<HumanController>().humanDurability = durability;
            }

            else if (character.gameObject.name == "Elf")
            {
                character.GetComponent<ElfController>().elfSpeed = speed;
                character.GetComponent<ElfController>().elfDurability = durability;
            }

            else if (character.gameObject.name == "Dwarf")
            {
                character.GetComponent<DwarfController>().dwarfSpeed = speed;
                character.GetComponent<DwarfController>().dwarfDurability = durability;
            }

            workForOnce = false;
        }
       
    }
}
