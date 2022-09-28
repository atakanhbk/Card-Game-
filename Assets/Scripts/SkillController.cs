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
    public GameObject cantUseSkill;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Money.GetComponent<MoneyText>().moneyAmount <= 0)
        {
            cantUseSkill.SetActive(true);
            skillCooldown.GetComponent<Image>().fillAmount = 0;
            skillCooldown.GetComponent<Image>().fillAmount = 0;
            skillCooldown.GetComponent<Image>().fillAmount = 0;
        }

        else
        {
            cantUseSkill.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Alpha1) && canSkillUse && gameObject.name == "Skill Icon 1")
            {

                Money.GetComponent<MoneyText>().moneyAmount -= 500;
                Money.GetComponent<MoneyText>().goldOrb.GetComponent<Image>().fillAmount -= 0.16f;
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
                Money.GetComponent<MoneyText>().moneyAmount -= 500;
                Money.GetComponent<MoneyText>().goldOrb.GetComponent<Image>().fillAmount -= 0.16f;
                skillCooldown.SetActive(true);
                canSkillUse = false;
                isSkillEnabled = true;
                skillCooldown.GetComponent<Image>().fillAmount = 1;
                directionArrowsForSkill.SetActive(false);
                skill2Used = false;
            }

            else if (Input.GetKeyDown(KeyCode.Alpha3) && canSkillUse && gameObject.name == "Skill Icon 3")
            {
                Money.GetComponent<MoneyText>().moneyAmount -= 1500;
                Money.GetComponent<MoneyText>().goldOrb.GetComponent<Image>().fillAmount -= 0.5f;
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

                    spawnCharacterController.GetComponent<SpawnCharacterController>().fillAmountTimer = 0.003f;
                }
            }
        }

        if (cantUseSkill.activeSelf && isSkillEnabled)
        {
            skillEffectTimer += Time.deltaTime;

            if (skillEffectTimer >= 3)
            {
                skillEffectTimer = 0;
                isSkillEnabled = false;

                spawnCharacterController.GetComponent<SpawnCharacterController>().fillAmountTimer = 0.003f;
            }
        }

        if (Money.GetComponent<MoneyText>().moneyAmount < 500 && gameObject.name == "Skill Icon 1")
        {
            cantUseSkill.SetActive(true);
            skillCooldown.GetComponent<Image>().fillAmount = 0;
        }

        if (Money.GetComponent<MoneyText>().moneyAmount < 500 && gameObject.name == "Skill Icon 2")
        {
            cantUseSkill.SetActive(true);
            skillCooldown.GetComponent<Image>().fillAmount = 0;

        }

        if (Money.GetComponent<MoneyText>().moneyAmount < 1500 && gameObject.name == "Skill Icon 3")
        {
            cantUseSkill.SetActive(true);
            skillCooldown.GetComponent<Image>().fillAmount = 0;
        }
       

    }
}
