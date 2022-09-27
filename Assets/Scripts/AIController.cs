using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{


    float spawnChracterTimer = 0;

    float skillCooldownTimer = 0;
    float skillActiaveTimer = 0;
   

    public List<GameObject> directionList = new List<GameObject>();
    public List<GameObject> characterList = new List<GameObject>();

    public GameObject AngryFist;

    public GameObject[] enemies;

    public static bool speedBoostActivate = false;

    public int levelDifficulty; //Level Difficulty eðer 1 ise = EASY  || Level Difficulty eðer 2 ise = MEDIUM || Level Difficulty eðer 3 ise = HARD

    int spawnCharacterCooldown = 20;
    int skillCooldown = 20;

    private void Start()
    {
        if (levelDifficulty == 1)
        {
            spawnCharacterCooldown = 10;
            skillCooldown = 15;
        }

        else if (levelDifficulty == 2)
        {
            spawnCharacterCooldown = 7;
            skillCooldown = 12;
        }

        else if (levelDifficulty == 3)
        {
            spawnCharacterCooldown = 5;
            skillCooldown = 10;
        }
    }
    private void Update()
    {
        
        SpawnCharacterFunction();

        UseSkillFunction();
    }

    void SpawnCharacterFunction()
    {
        spawnChracterTimer += Time.deltaTime;

        if (spawnChracterTimer >= spawnCharacterCooldown)
        {
            int randomDirection = Random.Range(0, 4);
            int randomCharacter = Random.Range(0, 3);

            if (characterList[randomCharacter].gameObject.tag == "Human")
            {
                var spawnedCharacter = Instantiate(characterList[randomCharacter], directionList[randomDirection].transform.position, Quaternion.Euler(0,0, 0));

                spawnedCharacter.gameObject.name = "" + spawnedCharacter.gameObject.tag + "Deneme";
                spawnedCharacter.gameObject.tag = "Enemy";
                spawnChracterTimer = 0;
            }
            else
            {
                var spawnedCharacter = Instantiate(characterList[randomCharacter], directionList[randomDirection].transform.position, Quaternion.Euler(0, 0, 0));

                spawnedCharacter.gameObject.name = "" + spawnedCharacter.gameObject.tag + "Deneme";
                spawnedCharacter.gameObject.tag = "Enemy";
                spawnChracterTimer = 0;
            }


        }
    }

    void UseSkillFunction()
    {
      
       
            skillCooldownTimer += Time.deltaTime;

            if (skillCooldownTimer >= skillCooldown)
            {
            //int chooseRandomSkill = Random.Range(0,3);
            int chooseRandomSkill = 1;

                if (chooseRandomSkill == 0)
                {
                        speedBoostActivate = true;
                        skillCooldownTimer = 0;
                }

                else if (chooseRandomSkill == 1)
                {
                int randomDirection = Random.Range(0, 4);
                var spawnedSkill =  Instantiate(AngryFist, directionList[randomDirection].transform.position, Quaternion.Euler(0,-90,0));
                spawnedSkill.gameObject.tag = "Enemy";
                skillCooldownTimer = 0;
                }
               
            }

            if (speedBoostActivate)
            {
                skillActiaveTimer += Time.deltaTime;

                if (skillActiaveTimer >= 3)
                {
                    skillActiaveTimer = 0;
                    speedBoostActivate = false;
                }
            }
      
      
    }
}
