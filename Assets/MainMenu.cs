using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject AIController;
   
   public void PlayGame()
    {
  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } 
    public void NextGame()
    {
  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void EasyLevel()
    {
        AIController.GetComponent<AIController>().levelDifficulty = 1;
    }

    public void MediumLevel()
    {
        AIController.GetComponent<AIController>().levelDifficulty = 2;
    }

    public void HardLevel()
    {
        AIController.GetComponent<AIController>().levelDifficulty = 3;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

   

}
