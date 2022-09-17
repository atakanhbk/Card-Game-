using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfController : MonoBehaviour
{
    Rigidbody rb;

    public int dwarfSpeed;
    public int dwarfDurability;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(dwarfSpeed, 0, 0);
    }
}
