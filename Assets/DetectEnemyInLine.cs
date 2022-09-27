using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemyInLine : MonoBehaviour
{
    public int numberOfEnemies = 0;

    private void Update()
    {
        Debug.Log("" + gameObject.name + " Enemy Number is = " + numberOfEnemies);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Human" || other.gameObject.tag == "Elf" || other.gameObject.tag == "Dwarf")
        {
            numberOfEnemies++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Human" || other.gameObject.tag == "Elf" || other.gameObject.tag == "Dwarf")
        {
            numberOfEnemies--;
        }
    }
}
