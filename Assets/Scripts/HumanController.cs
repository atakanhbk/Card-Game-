using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanController : MonoBehaviour
{
    Rigidbody rb;

    public float humanSpeed;
    public float humanDurability;
    public float humanPowerSpeed;

    public GameObject enemyHealth;
    public GameObject ourHealth;
    float timerToDoSomething = 0;

    [SerializeField] float damagePerSecond;
    [SerializeField] int damage;


    public Canvas damageEffect;

    public ParticleSystem ileriSurtunmeEffect1;
    public ParticleSystem ileriSurtunmeEffect2;

    public ParticleSystem geriyeSurtunmeEffect1;
    public ParticleSystem geriyeSurtunmeEffect2;



    bool moveForward;
    bool moveBack;

    void Start()
    {


        rb = GetComponent<Rigidbody>();

        humanPowerSpeed = ((humanSpeed * humanDurability) / 30);

        if (gameObject.name == "HumanDeneme")
        {
            enemyHealth = GameObject.FindGameObjectWithTag("OurHealth");
            ourHealth = GameObject.FindGameObjectWithTag("EnemyHealth");
        }
        else
        {
            enemyHealth = GameObject.FindGameObjectWithTag("EnemyHealth");
            ourHealth = GameObject.FindGameObjectWithTag("OurHealth");
        }



    }

    // Update is called once per frame
    void Update()
    {
       StartCoroutine(CheckCharacterMoveForward());
        if (gameObject.name == "HumanDeneme")
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
                if (timerToDoSomething== 0)
                {
                    enemyHealth.GetComponent<EnemyHealthController>().enemyHealth -= damage;
                    ourHealth.GetComponent<OurHealthController>().ourHealth += damage;
                }
                timerToDoSomething += Time.deltaTime;

                if (timerToDoSomething >= damagePerSecond)
                {
               
                    timerToDoSomething = 0;
                }

            }
        }
        if (gameObject.name =="HumanDeneme")
        {
            rb.velocity = new Vector3(-humanSpeed, 0, 0);
        }
        else
        {
            rb.velocity = new Vector3(humanSpeed, 0, 0);
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Floor")
        {
            humanSpeed = humanPowerSpeed;
         

        }

        if (collision.gameObject.tag == "Base")
        {
            if (gameObject.name == "HumanDeneme")
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

        if (gameObject.name == "HumanDeneme")
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
