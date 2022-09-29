using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrowForSkillController : MonoBehaviour
{
    public GameObject punch;

    public GameObject skill2;

    public GameObject humanCard;
    public GameObject elfCard;
    public GameObject dwarfCard;
    public void SendPunchForSkill2()
    {
        Instantiate(punch,transform.position, Quaternion.Euler(0, 90, 0));

       
       
        skill2.GetComponent<SkillController>().skill2Used = true;
    }

   
}
