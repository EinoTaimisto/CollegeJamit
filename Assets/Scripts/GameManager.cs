using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    [Header("TextField")]
    public Text QuestBox;
    public Text timerText;

    private bool questActivated = false;

    public double currentTime;
    public bool countDown;

    void Update()
    {
        if (questActivated)
        {
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
            timerText.text = currentTime.ToString("00.00");
        }
    }

}
