using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseController : MonoBehaviour
{
    public CameraShake cameraShake;
    public GameObject screenDamageImage;

    float screenDamageColorA;

    bool canShowScreenDamage = false;

    private void OnCollisionEnter(Collision collision)
    {
        screenDamageColorA = 0.5f;
        StartCoroutine(cameraShake.Shake(.15f, .4f));

        canShowScreenDamage = true;
    }

    private void Update()
    {

        if (screenDamageColorA >= 0 && canShowScreenDamage)
        {
            screenDamageImage.GetComponent<Image>().color = new Vector4(1, 1, 1, screenDamageColorA);
            screenDamageColorA -= Time.deltaTime / 10;
          
        }
        else
        {
            canShowScreenDamage = false;
            
        }
    }
}
