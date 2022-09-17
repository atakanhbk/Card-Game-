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
    [SerializeField] float damagePerSecond;
    [SerializeField] int damage;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        elfPowerSpeed = (elfSpeed * elfDurability) / 30;

        if (gameObject.name == "ElfDeneme")
        {
            enemyHealth = GameObject.FindGameObjectWithTag("OurHealth");
        }
        else
        {
            enemyHealth = GameObject.FindGameObjectWithTag("EnemyHealth");
        }
   
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.name == "ElfDeneme")
        {
            if (transform.position.x <= 0)
            {
                timerToDoSomething += Time.deltaTime;

                if (timerToDoSomething >= damagePerSecond)
                {
                    enemyHealth.GetComponent<OurHealthController>().ourHealth -= damage;
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

        if (collision.gameObject.name != "Floor")
        {
            elfSpeed = elfPowerSpeed;

        }
      
    }
}
