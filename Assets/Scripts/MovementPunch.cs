using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPunch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
            transform.Translate(0.7f, 0, 0);
        transform.Rotate(new Vector3(2, 0, 0));
    
    }
}
