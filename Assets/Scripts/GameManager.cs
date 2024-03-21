using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Spawners")]
    public GameObject characterModel;
    public Transform characterSpawnPoint;
    public GameObject trashcanPrefab;
    public Transform[] trashcanSpawnPoints;
    public GameObject notePrefab;
    public Transform[] noteSpawnPoints;

    [Header("TextField")]
    public Text QuestBox;
    public Text timerText;

    private bool questActivated = false;
    private string currentQuestType;
    private int trashcansCollected = 0;
    private int notesCollected = 0;
    private bool playerNearMika = false;
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
    void StartQuest()
    {
        string[] questTypes = { "Auta Mikaa SQL:n kanssa", "Tyhjennä roskikset", "Nouda minulle tietoja" };
        string randomQuest = questTypes[Random.Range(0, questTypes.Length)];
        Debug.Log("New Quest: " + randomQuest);
        QuestBox.text = randomQuest;
        questActivated = true;



        if (randomQuest == "Auta Mikaa SQL:n kanssa")
        {
            StartCoroutine(ActivateCharacter());
        }
        else if (randomQuest == "Tyhjennä roskikset")
        {
            StartCoroutine(SpawnTrashcans());
        }
        else if (randomQuest == "Nouda minulle tärkeää tietoa sisältävät laput")
        {
            StartCoroutine(SpawnNotes());
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BossRoom"))
        {
            StartQuest();
        }
        else if (collision.CompareTag("Player"))
        {
            playerNearMika = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearMika = false;
            if (questActivated && currentQuestType == "Auta Mikaa SQL:n kanssa")
            {
                ClearQuest();
            }
        }
    }

  
    IEnumerator ActivateCharacter()
    {
        characterModel.SetActive(true);
        yield return new WaitForSeconds(5f); // Assuming it takes 5 seconds to complete the task
        characterModel.SetActive(false);
        ClearQuest();
    }

    IEnumerator SpawnTrashcans()
    {
        foreach (Transform spawnPoint in trashcanSpawnPoints)
        {
            Instantiate(trashcanPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        yield return new WaitUntil(() => trashcansCollected >= 5); // Wait until all trashcans are collected
        ClearQuest();
    }

    IEnumerator SpawnNotes()
    {
        foreach (Transform spawnPoint in noteSpawnPoints)
        {
            Instantiate(notePrefab, spawnPoint.position, spawnPoint.rotation);
        }
        yield return new WaitUntil(() => notesCollected >= 10); // Wait until all notes are collected
        ClearQuest();
    }
    public void CollectTrashcan()
    {
        trashcansCollected++;
        QuestBox.text = "Roska kerätty! Enää " + (5 - trashcansCollected) + " jäljellä.";
        if (trashcansCollected >= 5)
            ClearQuest();
    }
    public void CollectNote()
    {
        notesCollected++;
        if (notesCollected >= 10)
            ClearQuest();
    }
    void ClearQuest()
    {
        questActivated = false;
        QuestBox.text = "";
        timerText.text = "23.00";
        currentQuestType = "";
        trashcansCollected = 0;
        notesCollected = 0;
    }
}
