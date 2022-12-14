using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerEnterCard : MonoBehaviour
{

    public bool isChosen = false;

    public GameObject directionsArrows;
    public GameObject directionsArrowsForSkill;

   public GameObject skill2;

    public Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.localPosition;

    }

    private void Update()
    {
        if (skill2.GetComponent<SkillController>().pressSkill && isChosen)
        {
 
            transform.localPosition = new Vector3(transform.localPosition.x, startPosition.y, transform.localPosition.z);

            
            isChosen = false;
        }
     
    }
    public void Pressed()
    {
     

        if (!isChosen)
        {
        
            if (transform.parent.GetComponent<ChoosenCard>().choosenCard != null && transform.parent.GetComponent<ChoosenCard>().choosenCard != gameObject)
            {
      
                transform.parent.GetComponent<ChoosenCard>().choosenCard.gameObject.transform.GetComponent<PointerEnterCard>().isChosen = false;
                transform.parent.GetComponent<ChoosenCard>().choosenCard.gameObject.transform.localPosition = new Vector3(transform.parent.GetComponent<ChoosenCard>().choosenCard.gameObject.transform.localPosition.x, startPosition.y, transform.parent.GetComponent<ChoosenCard>().choosenCard.gameObject.transform.localPosition.z);
            }
          
            isChosen = true;
            skill2.GetComponent<SkillController>().pressSkill = false;
            transform.parent.GetComponent<ChoosenCard>().choosenCard = gameObject;
            directionsArrows.SetActive(true);
            directionsArrowsForSkill.SetActive(false);
            transform.localPosition = new Vector3(transform.localPosition.x, startPosition.y+ 40, transform.localPosition.z);

          
        }


        else if (isChosen )
        {
           
            isChosen = false;

            directionsArrows.SetActive(false);
            transform.localPosition = new Vector3(transform.localPosition.x, startPosition.y, transform.localPosition.z);

        }


      
    }


}
