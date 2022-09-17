using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfController : MonoBehaviour
{
    Rigidbody rb;

    public int elfSpeed;
    public int elfDurability;

    public GameObject cardDataBase;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        
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
}
