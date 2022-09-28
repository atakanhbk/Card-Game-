using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{


    float spawnChracterTimer = 0;

    float skillCooldownTimer = 0;
    float skillActiaveTimer = 0;

    public List<GameObject> directionsWhichHasEnemy =  new List<GameObject>();
    public List<GameObject> directionList = new List<GameObject>();
    public List<GameObject> characterList = new List<GameObject>();

    public GameObject AngryFist;

    public GameObject[] enemies;

    public static bool speedBoostActivate = false;

    public int levelDifficulty; //Level Difficulty eðer 1 ise = EASY  || Level Difficulty eðer 2 ise = MEDIUM || Level Difficulty eðer 3 ise = HARD

    int spawnCharacterCooldown = 10;
    int skillCooldown = 10;

    private void Start()
    {
        if (levelDifficulty == 1)
        {
            spawnCharacterCooldown = 15;
            skillCooldown = 20;
        }

        else if (levelDifficulty == 2)
        {
            spawnCharacterCooldown = 10;
            skillCooldown = 15;
        }

        else if (levelDifficulty == 3)
        {
            spawnCharacterCooldown = 5;
            skillCooldown = 7;
        }
    }
    private void Update()
    {
        if (levelDifficulty == 1)
        {
            RandomSpawnCharacterFunction();
            RandomUseSkillFunction();
        }
        else if (levelDifficulty == 2)
        {
            SpawnCharacterSmartFunction();
            RandomUseSkillFunction();
        }
        else if (levelDifficulty == 3)
        {
            SpawnCharacterSmartFunction();
            UseSkillSmartFunction();
        }
       

       
    }

    void RandomSpawnCharacterFunction()
    {
        spawnChracterTimer += Time.deltaTime;

        if (spawnChracterTimer >= spawnCharacterCooldown)
        {
            int randomDirection = Random.Range(0, 4);
            int randomCharacter = Random.Range(0, 3);

       
                var spawnedCharacter = Instantiate(characterList[randomCharacter], directionList[randomDirection].transform.position, Quaternion.Euler(0,0, 0));

                spawnedCharacter.gameObject.name = "" + spawnedCharacter.gameObject.tag + "Deneme";
                spawnedCharacter.gameObject.tag = "Enemy";
                spawnChracterTimer = 0;
          
         


        }
    }

    void RandomUseSkillFunction()
    {
      
       
            skillCooldownTimer += Time.deltaTime;

            if (skillCooldownTimer >= skillCooldown)
            {
            int chooseRandomSkill = Random.Range(0,3);
           

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


    void SpawnCharacterSmartFunction()
    {
        spawnChracterTimer += Time.deltaTime;

        if (spawnChracterTimer >= spawnCharacterCooldown)
        {
            
            int randomCharacter = Random.Range(0, 3);
            int smartDirection = Random.Range(0, directionsWhichHasEnemy.Count);
            directionsWhichHasEnemy.Clear();
            for (int i = 0; i < directionList.Count; i++)
            {
               


                if (directionList[i].GetComponent<DetectEnemyInLine>().numberOfEnemies > 0)
                {
                    directionsWhichHasEnemy.Add(directionList[i]);
                    
                }
            }

            if (directionsWhichHasEnemy.Count> 0)
            {
                var spawnedCharacter = Instantiate(characterList[randomCharacter], directionsWhichHasEnemy[smartDirection].transform.position, Quaternion.Euler(0, 0, 0));
                spawnedCharacter.gameObject.name = "" + spawnedCharacter.gameObject.tag + "Deneme";
                spawnedCharacter.gameObject.tag = "Enemy";
                spawnChracterTimer = 0;
            }
            else
            {
                int randomDirection = Random.Range(0, 4);
                var spawnedCharacter = Instantiate(characterList[randomCharacter], directionList[randomDirection].transform.position, Quaternion.Euler(0, 0, 0));
                spawnedCharacter.gameObject.name = "" + spawnedCharacter.gameObject.tag + "Deneme";
                spawnedCharacter.gameObject.tag = "Enemy";
                spawnChracterTimer = 0;
            }
           

          

        }
    }

    void UseSkillSmartFunction()
    {
        skillCooldownTimer += Time.deltaTime;

        if (skillCooldownTimer >= skillCooldown)
        {
            int chooseRandomSkill = Random.Range(0,3);
           

            if (chooseRandomSkill == 0)
            {
                speedBoostActivate = true;
                skillCooldownTimer = 0;
            }

            else if (chooseRandomSkill == 1)
            {
                int randomDirection = Random.Range(0, directionsWhichHasEnemy.Count);
                var spawnedSkill = Instantiate(AngryFist, directionsWhichHasEnemy[randomDirection].transform.position, Quaternion.Euler(0, -90, 0));
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
