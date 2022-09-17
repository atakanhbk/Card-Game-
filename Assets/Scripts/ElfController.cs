using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfController : MonoBehaviour
{
    Rigidbody rb;

    public float elfSpeed;
    public float elfDurability;
    public float elfPowerSpeed;

    public GameObject cardDataBase;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        elfPowerSpeed = (elfSpeed * elfDurability) / 30;
    }

    // Update is called once per frame
    void Update()
    {


        if (gameObject.name == "ElfDeneme")
        {
            rb.velocity = new Vector3(-elfSpeed, 0, 0);
        }
        else
        {
            rb.velocity = new Vector3(elfSpeed, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name != "Floor")
        {
            elfSpeed = elfPowerSpeed;

        }
      
    }
}
