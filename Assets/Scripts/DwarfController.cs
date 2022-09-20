using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfController : MonoBehaviour
{
    Rigidbody rb;

    public float dwarfSpeed;
    public float dwarfDurability;
    public float dwarfPowerSpeed;

    float timerToDoSomething = 0;
    public GameObject enemyHealth;
    public GameObject ourHealth;
    public GameObject speedBoost;

    [SerializeField] float damagePerSecond;
    [SerializeField] int damage;


    public Canvas damageEffect;


    bool moveForward;
    bool moveBack;
    bool isCharacterFightingNow = false;


    GameObject skill1;
    GameObject skill2;
    GameObject skill3;

    float boostDwarfSpeed;
    float boostDwarfPowerSpeed;

    Animator dwarfAnim;

    float startSpeed;
    void Start()
    {
        startSpeed = dwarfSpeed;
        dwarfAnim = transform.GetChild(0).gameObject.GetComponent<Animator>();
        skill1 = GameObject.FindGameObjectWithTag("Skill1");
        skill2 = GameObject.FindGameObjectWithTag("Skill2");
        skill3 = GameObject.FindGameObjectWithTag("Skill3");

       


        rb = GetComponent<Rigidbody>();

        if (gameObject.name == "DwarfDeneme")
        {
            enemyHealth = GameObject.FindGameObjectWithTag("OurHealth");
            ourHealth = GameObject.FindGameObjectWithTag("EnemyHealth");
        }
        else
        {
            enemyHealth = GameObject.FindGameObjectWithTag("EnemyHealth");
            ourHealth = GameObject.FindGameObjectWithTag("OurHealth");
        }


        dwarfPowerSpeed = ((dwarfSpeed * dwarfDurability) / 30);

        boostDwarfSpeed = dwarfSpeed * 2f;
        boostDwarfPowerSpeed = dwarfPowerSpeed * 2;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag != "Enemy")
        {
            if (skill1.GetComponent<SkillController>().isSkillEnabled)
            {
                speedBoost.SetActive(true);
                if (isCharacterFightingNow)
                {
                    dwarfAnim.SetBool("push", true);
                    dwarfSpeed = boostDwarfPowerSpeed;
                }
                else
                {
                    dwarfAnim.SetBool("fastRun", true);
                    dwarfSpeed = boostDwarfSpeed;
                }
               
            }
            else
            {
                speedBoost.SetActive(false);
                dwarfAnim.SetBool("fastRun", false);
                if (isCharacterFightingNow)
                {
                    dwarfAnim.SetBool("push", true);
                    dwarfSpeed = boostDwarfPowerSpeed / 2f;
                }
                else
                {
                    dwarfSpeed = boostDwarfSpeed / 2;
                }

            }
        }

        StartCoroutine(CheckCharacterMoveForward());


        if (gameObject.name == "DwarfDeneme")
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
       

        rb.velocity = new Vector3(dwarfSpeed, 0, 0);

        if (gameObject.name == "DwarfDeneme")
        {
            rb.velocity = new Vector3(-dwarfSpeed, 0, 0);
        }
        else
        {
            rb.velocity = new Vector3(dwarfSpeed, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            dwarfSpeed = dwarfPowerSpeed;
            isCharacterFightingNow = true;
            dwarfAnim.SetBool("push", true);
        }

        if (collision.gameObject.tag == "Base")
        {
            if (gameObject.name == "DwarfDeneme")
            {
                Instantiate(damageEffect, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
                enemyHealth.GetComponent<OurHealthController>().ourHealth -= damage * 10;
                ourHealth.GetComponent<EnemyHealthController>().enemyHealth += damage * 10; 
                Destroy(gameObject);
            }
            else
            {
                Instantiate(damageEffect, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
                enemyHealth.GetComponent<EnemyHealthController>().enemyHealth -= damage * 10;
                ourHealth.GetComponent<OurHealthController>().ourHealth += damage * 10;
                Destroy(gameObject);
            }
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            dwarfSpeed = startSpeed;
            isCharacterFightingNow = false;
            dwarfAnim.SetBool("push", false);
        }
    }



    IEnumerator CheckCharacterMoveForward()
    {
        float lastPos = transform.position.x;
        yield return new WaitForSeconds(0.1f);
        float currentPos = transform.position.x;

        if (gameObject.name == "DwarfDeneme")
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
