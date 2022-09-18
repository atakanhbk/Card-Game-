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

    [SerializeField] float damagePerSecond;
    [SerializeField] int damage;
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "DwarfDeneme")
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

        if (collision.gameObject.name != "Floor")
        {
            dwarfSpeed = dwarfPowerSpeed;

        }


    }
}
