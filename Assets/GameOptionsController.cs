using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptionsController : MonoBehaviour
{
    public GameObject GameOptionsMenu;
    public void OpenGameOptions()
    {
        GameOptionsMenu.SetActive(true);
   
    }
}
