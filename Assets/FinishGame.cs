using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public bool isGameFinished = false;


    void Start()
    {
        isGameFinished = true;
    }

    private void Update()
    {
      

        Destroy(GameObject.FindGameObjectWithTag("Human"));
        Destroy(GameObject.FindGameObjectWithTag("Elf"));
        Destroy(GameObject.FindGameObjectWithTag("Dwarf"));
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
    }
}
