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

    [Header("Timer Settings")]
    public Text timerText;
    public double currentTime;
    public bool countDown;

    [Header("Quests")]
    public Text QuestBox;

    void Start()
    {

    }
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("00.00");

    }

    void Quest()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        string[] questTypes = { "Auta mikaa SQL:n kanssa", "Tyhjennä roskikset", "Nouda minulle tietoja" };
        string randomQuest = questTypes[Random.Range(0, questTypes.Length)];
        Debug.Log("New Quest: " + randomQuest);
        QuestBox.text = randomQuest;
    }
}
