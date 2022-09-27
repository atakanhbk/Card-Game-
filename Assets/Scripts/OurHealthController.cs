using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OurHealthController : MonoBehaviour
{
    public int ourHealth = 100;
    Text ourHealthText;

    public GameObject loseScreen;
    void Start()
    {
        ourHealthText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ourHealthText.text = "" + ourHealth;

        if (ourHealth<=0)
        {
            loseScreen.gameObject.SetActive(true);
            loseScreen.transform.parent.gameObject.SetActive(true);
        }
    }
}

