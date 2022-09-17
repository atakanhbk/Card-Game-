using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OurHealthController : MonoBehaviour
{
    public int ourHealth = 100;
    Text ourHealthText;
    void Start()
    {
        ourHealthText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ourHealthText.text = "" + ourHealth;
    }
}

