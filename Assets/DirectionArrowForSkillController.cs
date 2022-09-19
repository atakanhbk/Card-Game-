using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrowForSkillController : MonoBehaviour
{
    public GameObject punch;

    public GameObject skill2;
    public void SendPunchForSkill2()
    {
        Instantiate(punch,transform.position,Quaternion.identity);

        skill2.GetComponent<SkillController>().skill2Used = true;
    }
}
