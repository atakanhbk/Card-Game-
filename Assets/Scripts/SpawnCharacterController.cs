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

    public float fillAmountTimer = 0.001f;

    public ParticleSystem spawnEffect;
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

          

            humanCardCooldown.GetComponent<Image>().fillAmount -= fillAmountTimer;
            elfCardCooldown.GetComponent<Image>().fillAmount -= fillAmountTimer;
            dwarfCardCooldown.GetComponent<Image>().fillAmount -= fillAmountTimer;

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
            Instantiate(spawnEffect, spawnTransformation[spawnTransformationNumber].transform.position+Vector3.up*10, Quaternion.identity);
            Instantiate(human, spawnTransformation[spawnTransformationNumber].transform.position+Vector3.up*9, Quaternion.Euler(0, 90, 0));
            
            canSpawn = false;
            spawnedCharacter = true;

            humanCardCooldown.GetComponent<Image>().fillAmount = 1;
            elfCardCooldown.GetComponent<Image>().fillAmount = 1;
            dwarfCardCooldown.GetComponent<Image>().fillAmount = 1;
        }

        else if (canSpawn && choosenCard.GetComponent<ChoosenCard>().choosenCard.gameObject.name == "ElfCard" && !spawnedCharacter)
        {
            Instantiate(spawnEffect, spawnTransformation[spawnTransformationNumber].transform.position + Vector3.up * 10, Quaternion.identity);
            Instantiate(elf, spawnTransformation[spawnTransformationNumber].transform.position, Quaternion.Euler(0,90,0));
            canSpawn = false;
            spawnedCharacter = true;

            humanCardCooldown.GetComponent<Image>().fillAmount = 1;
            elfCardCooldown.GetComponent<Image>().fillAmount = 1;
            dwarfCardCooldown.GetComponent<Image>().fillAmount = 1;
        }

        else if (canSpawn && choosenCard.GetComponent<ChoosenCard>().choosenCard.gameObject.name == "DwarfCard" && !spawnedCharacter)
        {
            Instantiate(spawnEffect, spawnTransformation[spawnTransformationNumber].transform.position + Vector3.up * 10, Quaternion.identity);
            Instantiate(dwarf, spawnTransformation[spawnTransformationNumber].transform.position, Quaternion.Euler(0, 90, 0));
            canSpawn = false;
            spawnedCharacter = true;

              humanCardCooldown.GetComponent<Image>().fillAmount = 1;
            elfCardCooldown.GetComponent<Image>().fillAmount = 1;
            dwarfCardCooldown.GetComponent<Image>().fillAmount = 1;
        }

    }
}
