using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfController : MonoBehaviour
{
    Rigidbody rb;

    public float elfSpeed;
    public float elfDurability;
    public float elfPowerSpeed;

    public GameObject cardDataBase;

    float timerToDoSomething = 0;
    public GameObject enemyHealth;
    public GameObject ourHealth;
    [SerializeField] float damagePerSecond;
    [SerializeField] int damage;


    public Canvas damageEffect;


    public ParticleSystem ileriSurtunmeEffect1;
    public ParticleSystem ileriSurtunmeEffect2;

    public ParticleSystem geriyeSurtunmeEffect1;
    public ParticleSystem geriyeSurtunmeEffect2;

    bool moveForward;
    bool moveBack;
    bool isCharacterFightingNow = false;

    GameObject skill1;
    GameObject skill2;
    GameObject skill3;


    float boostElfSpeed;
    float boostElfPowerSpeed;

 
    void Start()
    {
        skill1 = GameObject.FindGameObjectWithTag("Skill1");
        skill2 = GameObject.FindGameObjectWithTag("Skill2");
        skill3 = GameObject.FindGameObjectWithTag("Skill3");

    

        rb = GetComponent<Rigidbody>();

        elfPowerSpeed = (elfSpeed * elfDurability) / 30;

        if (gameObject.name == "ElfDeneme")
        {
            enemyHealth = GameObject.FindGameObjectWithTag("OurHealth");
            ourHealth = GameObject.FindGameObjectWithTag("EnemyHealth");
        }
        else
        {
            enemyHealth = GameObject.FindGameObjectWithTag("EnemyHealth");
            ourHealth = GameObject.FindGameObjectWithTag("OurHealth");
        }

        boostElfSpeed = elfSpeed * 2f;
        boostElfPowerSpeed = elfPowerSpeed * 2;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.tag != "Enemy")
        {

            if (skill1.GetComponent<SkillController>().isSkillEnabled)
            {
                if (isCharacterFightingNow)
                {
                    elfSpeed = boostElfPowerSpeed;
                }
                else
                {
                    elfSpeed = boostElfSpeed;
                }

            }
            else
            {
                if (isCharacterFightingNow)
                {
                    elfSpeed = boostElfPowerSpeed / 2f;
                }
                else
                {
                    elfSpeed = boostElfSpeed / 2;
                }

            }
        }

        StartCoroutine(CheckCharacterMoveForward());
        if (gameObject.name == "ElfDeneme")
        {
            if (transform.position.x <= 0)
            {
                if (timerToDoSomething == 0)
                {
                    enemyHealth.GetComponent<OurHealthController>().ourHealth -= damage;
                    ourHealth.GetComponent<EnemyHealthController>().enemyHealth += damage;
                }

                timerToDoSomething += Time.deltaTime;

                if (timerToDoSomething >= damagePerSecond)
                {
                    enemyHealth.GetComponent<OurHealthController>().ourHealth -= damage;
                    ourHealth.GetComponent<EnemyHealthController>().enemyHealth += damage;
                    timerToDoSomething = 0;
                }

            }
        }
        else
        {
            if (transform.position.x >= 0)
            {
                if (timerToDoSomething == 0)
                {
                    enemyHealth.GetComponent<EnemyHealthController>().enemyHealth -= damage;
                    ourHealth.GetComponent<OurHealthController>().ourHealth += damage;
                }
                timerToDoSomething += Time.deltaTime;

                if (timerToDoSomething >= damagePerSecond)
                {
                    enemyHealth.GetComponent<EnemyHealthController>().enemyHealth -= damage;
                    ourHealth.GetComponent<OurHealthController>().ourHealth += damage;
                    timerToDoSomething = 0;
                }

            }
        }

        if (gameObject.name == "ElfDeneme")
        {
            rb.velocity = new Vector3(-elfSpeed, 0, 0);
        }
        else
        {
            rb.velocity = new Vector3(elfSpeed, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
  

        if (collision.gameObject.tag == "Base")
        {
            if (gameObject.name == "ElfDeneme")
            {
                Instantiate(damageEffect, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
                enemyHealth.GetComponent<OurHealthController>().ourHealth -= damage * 10;
                ourHealth.GetComponent<EnemyHealthController>().enemyHealth += damage * 10;
        
                Destroy(gameObject);
            }
            else
            {
                Instantiate(damageEffect, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
                enemyHealth.GetComponent<EnemyHealthController>().enemyHealth -= damage*10;
                ourHealth.GetComponent<OurHealthController>().ourHealth += damage*10;
                Destroy(gameObject);
            }
          
        }


        if (collision.gameObject.name != "Floor")
        {
            elfSpeed = elfPowerSpeed;
            isCharacterFightingNow = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name != "Floor")
        {
            if (moveForward)
            {
                ileriSurtunmeEffect1.gameObject.SetActive(true);
                ileriSurtunmeEffect2.gameObject.SetActive(true);
                geriyeSurtunmeEffect1.gameObject.SetActive(false);
                geriyeSurtunmeEffect2.gameObject.SetActive(false);
            }
            else if (moveBack)
            {
                ileriSurtunmeEffect1.gameObject.SetActive(false);
                ileriSurtunmeEffect2.gameObject.SetActive(false);
                geriyeSurtunmeEffect1.gameObject.SetActive(true);
                geriyeSurtunmeEffect2.gameObject.SetActive(true);
            }


        }

    }

    IEnumerator CheckCharacterMoveForward()
    {
        float lastPos = transform.position.x;
        yield return new WaitForSeconds(0.1f);
        float currentPos = transform.position.x;

        if (gameObject.name == "ElfDeneme")
        {
            if (lastPos > currentPos)
            {
                moveForward = true;
                moveBack = false;

            }
            else
            {
                moveForward = false;
                moveBack = true;
            }
        }
        else
        {
            if (lastPos < currentPos)
            {
                moveForward = true;
                moveBack = false;

       
            }
            else
            {
                moveForward = false;
                moveBack = true;
            }
        }
      
    }
}
