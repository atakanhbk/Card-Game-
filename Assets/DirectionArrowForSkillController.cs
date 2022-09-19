using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrowForSkillController : MonoBehaviour
{
    public GameObject punch;
    
    public void SendPunchForSkill2()
    {
        Instantiate(punch,transform.position,Quaternion.identity);
    }
}
