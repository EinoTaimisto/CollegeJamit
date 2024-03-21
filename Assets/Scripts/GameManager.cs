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

    private bool questActivated = false;
    //public string QuestType;

    void Start()
    {

    }

    void Update()
    {
        if (questActivated)
        {
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
            timerText.text = currentTime.ToString("00.00");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("BossRoom"))
        {
            string[] questTypes = { "Auta Mikaa SQL:n kanssa", "Tyhjennä roskikset", "Nouda minulle tietoja" };
            string randomQuest = questTypes[Random.Range(0, questTypes.Length)];
            Debug.Log("New Quest: " + randomQuest);
            QuestBox.text = randomQuest;

            string QuestType = randomQuest;
            currentTime = 0;
            questActivated = true;
        }
    }

    void Quest(string QuestType)
    {
        if (QuestType == "Auta mikaa SQL:n kanssa") {
            Debug.Log("Mika Quest");


        }
        else if(QuestType == "Tyhjennä roskikset")
        {
            Debug.Log("Roskalava");


        }
        else if(QuestType == "Nouda minulle tietoja"){
            Debug.Log("Tiedonkeruu");

        }
        else
        {
            questActivated = false;
        }
    }


}