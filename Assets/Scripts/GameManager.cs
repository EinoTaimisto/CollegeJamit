using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class NewBehaviourScript : MonoBehaviour
{
    public float timeElapsed;
    public GameObject PlayFieldCanvas;

    [Header("Component")]
    public Text timerText;

    [Header("Timer Settings")]
    public double currentTime;
    public bool countDown;

    void Start()
    {

    }
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("00.00");

    }

}
