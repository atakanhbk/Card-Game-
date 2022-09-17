using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionArrowController : MonoBehaviour
{
    public GameObject spawnCharacterController;

    int directionNumber;

    public void ThisWayChoosen()
    {
        directionNumber = int.Parse(gameObject.name);

        spawnCharacterController.GetComponent<SpawnCharacterController>().spawnTransformationNumber = directionNumber;
        spawnCharacterController.GetComponent<SpawnCharacterController>().canSpawn = true;
    }

    private void Update()
    {
        Debug.Log("wOKÝRNG");
    }
}
