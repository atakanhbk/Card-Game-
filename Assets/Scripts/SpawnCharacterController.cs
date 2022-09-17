using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterController : MonoBehaviour
{
    public GameObject human;
    public GameObject elf;
    public GameObject dwarf;
    public GameObject choosenCard;

    public List<GameObject> spawnTransformation = new List<GameObject>();

    public bool canSpawn = false;
    public int spawnTransformationNumber;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        DecideSpawnObject();
    }

    void DecideSpawnObject()
    {
        if (canSpawn && choosenCard.GetComponent<ChoosenCard>().choosenCard.gameObject.name == "HumanCard")
        {
            Instantiate(human, spawnTransformation[spawnTransformationNumber].transform.position, Quaternion.identity);
            canSpawn = false;
        }

        else if (canSpawn && choosenCard.GetComponent<ChoosenCard>().choosenCard.gameObject.name == "ElfCard")
        {
            Instantiate(elf, spawnTransformation[spawnTransformationNumber].transform.position, Quaternion.identity);
            canSpawn = false;
        }

        else if (canSpawn && choosenCard.GetComponent<ChoosenCard>().choosenCard.gameObject.name == "DwarfCard")
        {
            Instantiate(dwarf, spawnTransformation[spawnTransformationNumber].transform.position, Quaternion.identity);
            canSpawn = false;
        }

    }
}
