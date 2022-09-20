using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushEnemies : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.transform.Translate(1.5f, 0, 0);
        }
    }
}