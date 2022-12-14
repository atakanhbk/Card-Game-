using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour
{
    public int enemyHealth = 100;
    Text enemyHealthText;

    public GameObject winScreen;
    void Start()
    {
        enemyHealthText = gameObject.GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthText.text = "" + enemyHealth;

        if (enemyHealth<= 0)
        {
            winScreen.SetActive(true);
            winScreen.transform.parent.gameObject.SetActive(true);
        }
    }
}
