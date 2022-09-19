using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    public GameObject skillCooldown;
    float skill1CooldownTimer = 1;
    bool canSkillUse = true;

    float skillEffectTimer = 0;
    public bool isSkillEnabled = false;

    public GameObject directionArrows;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && canSkillUse && gameObject.name =="Skill Icon 1")
        {
            skillCooldown.SetActive(true);
            canSkillUse = false;
            isSkillEnabled = true;
            skillCooldown.GetComponent<Image>().fillAmount = 1;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && canSkillUse && gameObject.name == "Skill Icon 2")
        {
            directionArrows.SetActive(true);
            /*
            skillCooldown.SetActive(true);
            canSkillUse = false;
            isSkillEnabled = true;
            skillCooldown.GetComponent<Image>().fillAmount = 1;
            */
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3) && canSkillUse && gameObject.name == "Skill Icon 3")
        {
            skillCooldown.SetActive(true);
            canSkillUse = false;
            isSkillEnabled = true;
            skillCooldown.GetComponent<Image>().fillAmount = 1;
        }


        if (!canSkillUse)
        {
           
            skillCooldown.GetComponent<Image>().fillAmount -= 0.0005f;

            if (skillCooldown.GetComponent<Image>().fillAmount <= 0)
            {
                canSkillUse = true;
            }
        }

        if (isSkillEnabled)
        {
            skillEffectTimer += Time.deltaTime;

            if (skillEffectTimer >= 5)
            {
                skillEffectTimer = 0;
                isSkillEnabled = false;
            }
        }


    }
}
