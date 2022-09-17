using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    Rigidbody rb;

    public float humanSpeed;
    public float humanDurability;
    public float humanPowerSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        humanPowerSpeed = ((humanSpeed * humanDurability) / 30);
    }

    // Update is called once per frame
    void Update()
    {
 

        if (gameObject.name =="HumanDeneme")
        {
            rb.velocity = new Vector3(-humanSpeed, 0, 0);
        }
        else
        {
            rb.velocity = new Vector3(humanSpeed, 0, 0);
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Floor")
        {
            humanSpeed = humanPowerSpeed;

        }


      
    }
    
}
