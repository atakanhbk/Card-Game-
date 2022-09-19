using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRawImage : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;

    RawImage myRawImage;
    void Start()
    {
        myRawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
