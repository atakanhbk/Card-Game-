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
    public GameObject speedBoost;
    

    [SerializeField] float damagePerSecond;
    [SerializeField] int damage;


    public Canvas damageEffect;


    GameObject skill1;
    GameObject skill2;
    GameObject skill3;


    bool moveForward;
    bool moveBack;

    float boostHumanSpeed;
    float boostHumanPowerSpeed;
    float timerToDoSomething = 0;

    

    bool isCharacterFightingNow = false;

    Animator humanAnim;

    float startSpeed;

    public ParticleSystem baseHitEffect;
    public ParticleSystem hammerMoveEffect;
    void Start()
    {
        humanAnim = transform.GetChild(0).gameObject.GetComponent<Animator>();
        startSpeed = humanSpeed;

        skill1 = GameObject.FindGameObjectWithTag("Skill1");
        skill2 = GameObject.FindGameObjectWithTag("Skill2");
        skill3 = GameObject.FindGameObjectWithTag("Skill3");

        rb = GetComponent<Rigidbody>();
        boostHumanSpeed = humanSpeed * 2;
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


        boostHumanSpeed = humanSpeed * 2f;
        boostHumanPowerSpeed = humanPowerSpeed * 2;
    }

    // Update is called once per frame
    void Update()
    {
       StartCoroutine(CheckCharacterMoveForward());

        if (gameObject.tag != "Enemy")
        {
          
            if (skill1.GetComponent<SkillController>().isSkillEnabled && gameObject.name != "HumanDeneme")
            {
                Debug.Log("Working");
                speedBoost.SetActive(true);
                if (isCharacterFightingNow)
                {
                    humanAnim.SetBool("push", true);
                    humanSpeed = boostHumanPowerSpeed;
                }
                else
                {
                    humanAnim.SetBool("fastRun", true);
                    humanSpeed = boostHumanSpeed;
                }

            }
            else
            {
                Debug.Log("Else Working");
                speedBoost.SetActive(false);
                humanAnim.SetBool("fastRun", false);
                if (isCharacterFightingNow)
                {
                    humanAnim.SetBool("push", true);
                    humanSpeed = boostHumanPowerSpeed / 2f;
                }
                else
                {
                    humanSpeed = boostHumanSpeed / 2;
                }

            }
        }



        if (gameObject.tag == "Enemy")
        {
            if (AIController.speedBoostActivate)
            {

                if (gameObject.tag == "Enemy")
                {
                    speedBoost.SetActive(true);
                    if (isCharacterFightingNow)
                    {
                        humanAnim.SetBool("push", true);
                        humanSpeed = boostHumanPowerSpeed;
                    }
                    else
                    {
                        humanAnim.SetBool("fastRun", true);
                        humanSpeed = boostHumanSpeed;
                    }

                }
                else
                {
                    speedBoost.SetActive(false);
                    humanAnim.SetBool("fastRun", false);
                    if (isCharacterFightingNow)
                    {
                        humanAnim.SetBool("push", true);
                        humanSpeed = boostHumanPowerSpeed / 2f;
                    }
                    else
                    {
                        humanSpeed = boostHumanSpeed / 2;
                    }

                }
            }
            else
            {
                speedBoost.SetActive(false);
                humanAnim.SetBool("fastRun", false);
                if (isCharacterFightingNow)
                {
                    humanAnim.SetBool("push", true);
                    humanSpeed = boostHumanPowerSpeed / 2f;
                }
                else
                {
                    humanSpeed = boostHumanSpeed / 2;
                }
            }

        }



        if (gameObject.name == "HumanDeneme")
        {
            if (transform.position.z >= 0)
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
            if (transform.position.z <= 0)
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
            rb.velocity = new Vector3(0, 0, humanSpeed);
        }
        else
        {
           rb.velocity = new Vector3(0, 0, -humanSpeed);
      
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name != "Floor")
        {
            humanSpeed = humanPowerSpeed;

            isCharacterFightingNow = true;
            humanAnim.SetBool("push", true);
        }



        if (collision.gameObject.tag == "Base")
        {
            Instantiate(baseHitEffect, transform.position + Vector3.up * 5, Quaternion.identity);
            if (gameObject.name == "HumanDeneme")
            {
                Instantiate(damageEffect, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
                enemyHealth.GetComponent<OurHealthController>().ourHealth -= damage * 10;
                ourHealth.GetComponent<EnemyHealthController>().enemyHealth += damage * 10;

              
            }
            else
            {
              
                Instantiate(damageEffect, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
                enemyHealth.GetComponent<EnemyHealthController>().enemyHealth -= damage * 10;
                ourHealth.GetComponent<OurHealthController>().ourHealth += damage * 10;
              
            }
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "EnemyBase")
        {
            Instantiate(baseHitEffect, transform.position + Vector3.up * 5, Quaternion.identity);
            if (gameObject.name == "HumanDeneme")
            {
                Instantiate(damageEffect, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
                enemyHealth.GetComponent<OurHealthController>().ourHealth += damage * 10;
                ourHealth.GetComponent<EnemyHealthController>().enemyHealth -= damage * 10;

            
            }
            else
            {
                Instantiate(damageEffect, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
                enemyHealth.GetComponent<EnemyHealthController>().enemyHealth -= damage * 10;
                ourHealth.GetComponent<OurHealthController>().ourHealth += damage * 10;
               
            }
            Destroy(gameObject);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name != "Floor")
        {
            humanSpeed = startSpeed;
            isCharacterFightingNow = false;
            humanAnim.SetBool("push", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Angry Punch(Clone)" && gameObject.tag =="Human" && other.gameObject.tag == "Enemy")
        {
            var spawnedEffect = Instantiate(hammerMoveEffect, transform.position+Vector3.up*2, Quaternion.identity);
            
            spawnedEffect.gameObject.transform.parent = transform;
            spawnedEffect.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if(other.gameObject.name == "Angry Punch(Clone)"&& other.gameObject.tag != "Enemy" && gameObject.tag == "Enemy")
        {
            var spawnedEffect = Instantiate(hammerMoveEffect, transform.position + Vector3.up * 2, Quaternion.Euler(new Vector3(180,0,0)));

            spawnedEffect.gameObject.transform.parent = transform;
            spawnedEffect.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name == "Angry Punch(Clone)" && gameObject.tag == "Human" && other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject.transform.GetChild(transform.childCount - 1).gameObject);
        }
        else if (other.gameObject.name == "Angry Punch(Clone)" && other.gameObject.tag != "Enemy" && gameObject.tag == "Enemy")
        {
            Destroy(gameObject.transform.GetChild(transform.childCount - 1).gameObject);
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
