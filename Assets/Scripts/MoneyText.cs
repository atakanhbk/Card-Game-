using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    public int moneyAmount = 3000;
    public GameObject goldOrb;
    Text moneyText;
    void Start()
    {
        moneyText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "+" + moneyAmount + "$";
    }
}
