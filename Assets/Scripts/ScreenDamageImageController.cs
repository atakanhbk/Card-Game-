using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenDamageImageController : MonoBehaviour
{

    float screenDamageColorA = 100;
    void Update()
    {
        GetComponent<Image>().color = new Vector4(255, 255, 255, GetComponent<Image>().color.a);

      
    }
}
