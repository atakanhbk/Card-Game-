using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfController : MonoBehaviour
{
    Rigidbody rb;

    public float dwarfSpeed;
    public float dwarfDurability;
    public float dwarfPowerSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        dwarfPowerSpeed = ((dwarfSpeed * dwarfDurability) / 30);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(dwarfSpeed, 0, 0);

        if (gameObject.name == "DwarfDeneme")
        {
            rb.velocity = new Vector3(-dwarfSpeed, 0, 0);
        }
        else
        {
            rb.velocity = new Vector3(dwarfSpeed, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name != "Floor")
        {
            dwarfSpeed = dwarfPowerSpeed;

        }


    }
}
