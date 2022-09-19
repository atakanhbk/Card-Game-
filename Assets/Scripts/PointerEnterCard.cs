using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerEnterCard : MonoBehaviour
{

    bool isChosen = false;

    public GameObject directionsArrows;
    public GameObject directionsArrowsForSkill;

    public void Pressed()
    {
     

        if (!isChosen)
        {

            if (transform.parent.GetComponent<ChoosenCard>().choosenCard != null && transform.parent.GetComponent<ChoosenCard>().choosenCard != gameObject)
            {
                transform.parent.GetComponent<ChoosenCard>().choosenCard.gameObject.transform.GetComponent<PointerEnterCard>().isChosen = false;
                transform.parent.GetComponent<ChoosenCard>().choosenCard.gameObject.transform.localPosition = new Vector3(transform.parent.GetComponent<ChoosenCard>().choosenCard.gameObject.transform.localPosition.x, 0, transform.parent.GetComponent<ChoosenCard>().choosenCard.gameObject.transform.position.z);
            }
            isChosen = true;

            transform.parent.GetComponent<ChoosenCard>().choosenCard = gameObject;
            directionsArrows.SetActive(true);
            directionsArrowsForSkill.SetActive(false);
            transform.localPosition = new Vector3(transform.localPosition.x, 40, transform.localPosition.z);

          
        }


        else if (isChosen)
        {
            isChosen = false;
            directionsArrows.SetActive(false);
         
            transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.position.z);
        }


      
    }


}
