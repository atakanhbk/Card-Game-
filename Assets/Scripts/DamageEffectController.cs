using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffectController : MonoBehaviour
{


    float timer = 0;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up , 30*Time.deltaTime);

        timer += Time.deltaTime;

        if (timer >= 1.5f)
        {
    
            Destroy(gameObject);
        }
    }
}
