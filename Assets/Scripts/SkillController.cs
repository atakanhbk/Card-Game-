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

    public GameObject directionArrowsForSkill;
    public GameObject directionArrows;

    public bool skill2Used = false;
    bool skill3Used = false;
    public GameObject Money;
    public GameObject spawnCharacterController;

    int moneyAmount;
    void Start()
    {
        moneyAmount = Money.GetComponent<MoneyText>().moneyAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && canSkillUse && gameObject.name =="Skill Icon 1")
        {
        
            moneyAmount -= 100;
            skillCooldown.SetActive(true);
            canSkillUse = false;
            isSkillEnabled = true;
            skillCooldown.GetComponent<Image>().fillAmount = 1;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && canSkillUse && gameObject.name == "Skill Icon 2")
        {
            directionArrowsForSkill.SetActive(true);
            directionArrows.SetActive(false);
        
        }

        if (skill2Used)
        {
            skillCooldown.SetActive(true);
            canSkillUse = false;
            isSkillEnabled = true;
            skillCooldown.GetComponent<Image>().fillAmount = 1;
            directionArrowsForSkill.SetActive(false);
            skill2Used = false;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3) && canSkillUse && gameObject.name == "Skill Icon 3")
        {

            spawnCharacterController.GetComponent<SpawnCharacterController>().fillAmountTimer = 0.01f;
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

            if (skillEffectTimer >= 3)
            {
                skillEffectTimer = 0;
                isSkillEnabled = false;

                spawnCharacterController.GetComponent<SpawnCharacterController>().fillAmountTimer = 0.001f;
            }
        }


    }
}
