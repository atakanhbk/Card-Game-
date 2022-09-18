using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        if (gameObject.name == "HumanDeneme")
        {
            if (transform.position.x <= 0)
            {
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
                timerToDoSomething += Time.deltaTime;

                if (timerToDoSomething >= damagePerSecond)
                {
                    enemyHealth.GetComponent<EnemyHealthController>().enemyHealth -= damage;
                    ourHealth.GetComponent<OurHealthController>().ourHealth += damage;
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

        if (collision.gameObject.name == "Base")
        {
            enemyHealth.GetComponent<EnemyHealthController>().enemyHealth -= damage * 3;
            ourHealth.GetComponent<OurHealthController>().ourHealth += damage * 3;
            Debug.Log("Working");
        }

    }
    
}
