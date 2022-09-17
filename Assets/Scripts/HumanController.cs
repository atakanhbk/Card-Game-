using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    Rigidbody rb;

    public int humanSpeed;
    public int humanDurability;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(humanSpeed,0,0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ElfDeneme")
        {
            if (humanDurability > collision.gameObject.GetComponent<ElfController>().elfDurability)
            {
               humanSpeed += (humanDurability - collision.gameObject.GetComponent<ElfController>().elfDurability)*2;
            }
        }
    }
}
