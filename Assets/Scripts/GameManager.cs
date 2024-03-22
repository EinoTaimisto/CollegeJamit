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



    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("00.00");
        //KillCount.text = gun.EnemyCount.ToString();

    }

}
