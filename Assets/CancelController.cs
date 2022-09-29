using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelController : MonoBehaviour
{
    public GameObject humanCard;
    public GameObject elfCard;
    public GameObject dwarfCard;

    public GameObject skill2;


    public void Cancel()
    {
        humanCard.transform.localPosition = humanCard.GetComponent<PointerEnterCard>().startPosition;
        humanCard.GetComponent<PointerEnterCard>().directionsArrows.SetActive(false);
        elfCard.transform.localPosition = elfCard.GetComponent<PointerEnterCard>().startPosition;
        elfCard.GetComponent<PointerEnterCard>().directionsArrows.SetActive(false);
        dwarfCard.transform.localPosition = dwarfCard.GetComponent<PointerEnterCard>().startPosition;
        dwarfCard.GetComponent<PointerEnterCard>().directionsArrows.SetActive(false);

        skill2.GetComponent<SkillController>().pressSkill = false;
        skill2.GetComponent<SkillController>().directionArrowsForSkill.SetActive(false);
    }
}
