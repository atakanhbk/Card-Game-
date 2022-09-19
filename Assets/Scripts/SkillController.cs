using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    public GameObject skillCooldown;
    float skill1CooldownTimer = 1;
    bool isSkilledUsed = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !isSkilledUsed && gameObject.name =="Skill Icon 1")
        {
            skillCooldown.SetActive(true);
            isSkilledUsed = true;
            skillCooldown.GetComponent<Image>().fillAmount = 1;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && !isSkilledUsed && gameObject.name == "Skill Icon 2")
        {
            skillCooldown.SetActive(true);
            isSkilledUsed = true;
            skillCooldown.GetComponent<Image>().fillAmount = 1;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3) && !isSkilledUsed && gameObject.name == "Skill Icon 3")
        {
            skillCooldown.SetActive(true);
            isSkilledUsed = true;
            skillCooldown.GetComponent<Image>().fillAmount = 1;
        }


        if (isSkilledUsed)
        {
            skillCooldown.GetComponent<Image>().fillAmount -= 0.001f;

            if (skillCooldown.GetComponent<Image>().fillAmount <= 0)
            {
                isSkilledUsed = false;
            }
        }
    }
}
