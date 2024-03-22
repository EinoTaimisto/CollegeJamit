using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject door;

    [Header("TextField")]
    public Text KillCount;
    public Text timerText;

    public double currentTime;
    public bool countDown;
    public Enemy enemy; 


    void Update()
    {
        
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("00.00");
        string KC = enemy.EnemyCount.ToString();
        KillCount.text = KC;

        if(KC == "0")
        {
            door.SetActive(false);
            //SceneManager.LoadScene("MainMenu");
        }

    }

}
