using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnCharacterController : MonoBehaviour
{
    public GameObject human;
    public GameObject elf;
    public GameObject dwarf;
    public GameObject choosenCard;

    public List<GameObject> spawnTransformation = new List<GameObject>();

    public bool canSpawn = false;

    public int spawnTransformationNumber;
    public GameObject directionArrows;
    float timerForSpawnNewCharacter = 0;
    bool spawnedCharacter = false;

    public GameObject humanCardCooldown;
    public GameObject elfCardCooldown;
    public GameObject dwarfCardCooldown;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        DecideSpawnObject();

        if (spawnedCharacter)
        {
            timerForSpawnNewCharacter += Time.deltaTime;
            choosenCard.GetComponent<ChoosenCard>().choosenCard.transform.localPosition = new Vector3(choosenCard.GetComponent<ChoosenCard>().choosenCard.transform.localPosition.x, 0, choosenCard.GetComponent<ChoosenCard>().choosenCard.transform.localPosition.z);
            directionArrows.SetActive(false);

          

            humanCardCooldown.GetComponent<Image>().fillAmount -= 0.001f;
            elfCardCooldown.GetComponent<Image>().fillAmount -= 0.001f;
            dwarfCardCooldown.GetComponent<Image>().fillAmount -= 0.001f;

            if (humanCardCooldown.GetComponent<Image>().fillAmount == 0 && elfCardCooldown.GetComponent<Image>().fillAmount == 0 && dwarfCardCooldown.GetComponent<Image>().fillAmount == 0)
            {
                spawnedCharacter = false;
            }
        }
    }

    void DecideSpawnObject()
    {
        if (canSpawn && choosenCard.GetComponent<ChoosenCard>().choosenCard.gameObject.name == "HumanCard" && !spawnedCharacter)
        {
            Instantiate(human, spawnTransformation[spawnTransformationNumber].transform.position, Quaternion.identity);
            canSpawn = false;
            spawnedCharacter = true;

            humanCardCooldown.GetComponent<Image>().fillAmount = 1;
            elfCardCooldown.GetComponent<Image>().fillAmount = 1;
            dwarfCardCooldown.GetComponent<Image>().fillAmount = 1;
        }

        else if (canSpawn && choosenCard.GetComponent<ChoosenCard>().choosenCard.gameObject.name == "ElfCard" && !spawnedCharacter)
        {
            Instantiate(elf, spawnTransformation[spawnTransformationNumber].transform.position, Quaternion.identity);
            canSpawn = false;
            spawnedCharacter = true;

            humanCardCooldown.GetComponent<Image>().fillAmount = 1;
            elfCardCooldown.GetComponent<Image>().fillAmount = 1;
            dwarfCardCooldown.GetComponent<Image>().fillAmount = 1;
        }

        else if (canSpawn && choosenCard.GetComponent<ChoosenCard>().choosenCard.gameObject.name == "DwarfCard" && !spawnedCharacter)
        {
            Instantiate(dwarf, spawnTransformation[spawnTransformationNumber].transform.position, Quaternion.identity);
            canSpawn = false;
            spawnedCharacter = true;

              humanCardCooldown.GetComponent<Image>().fillAmount = 1;
            elfCardCooldown.GetComponent<Image>().fillAmount = 1;
            dwarfCardCooldown.GetComponent<Image>().fillAmount = 1;
        }

    }
}
