using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushEnemies : MonoBehaviour
{
    [SerializeField] float pushPower;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && gameObject.tag == "Untagged")
        {
            other.gameObject.transform.Translate(0, 0, -pushPower);
        }

        else if (other.gameObject.tag == "Human" && gameObject.tag == "Enemy" || other.gameObject.tag == "Elf" && gameObject.tag == "Enemy" || other.gameObject.tag == "Dwarf" && gameObject.tag == "Enemy")
        {
            Debug.Log("Working");
            other.gameObject.transform.Translate(0, 0, -pushPower);
        }
    }
}
