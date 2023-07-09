using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardManager : MonoBehaviour
{
    public List<GameObject> playerCards = new List<GameObject>();
    private GameObject newCard;
    public GameObject card;
    public GameObject cardContainer;

    public List<string> cardTypes = new List<string> { "character", "ninja", "lute" };
    public List<string> cardDescriptions = new List<string> { "Mighty Warrior!", "Force blow!", "Boost your health!" };

    public bool isRoundFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePlayerCards();
        InitializeCards();

    }

    // Update is called once per frame
    void Update()
    {
        /*if (isRoundFinished)
        {
            updateCards();
        } */
        /*if (RhythmGameManager.instance.winCond == 2)
        {
            //increase players health
            RhythmGameManager.instance.winCond = 1;
        }

        if (RhythmGameManager.instance.winCond == 0)
        {
            //show player he is looser
            RhythmGameManager.instance.winCond = 1;
        }*/
    }

    void GeneratePlayerCards()
    {
        for (int i = 0; i < 3; i++)
        {
            newCard = Instantiate(card, gameObject.transform);
            playerCards.Add(newCard);
        }
    }

    void InitializeCards()
    {
        playerCards[0].GetComponent<CardScript>().cardType = cardTypes[0];
        playerCards[0].GetComponent<CardScript>().description = cardDescriptions[0];

        playerCards[1].GetComponent<CardScript>().cardType = cardTypes[1];
        playerCards[1].GetComponent<CardScript>().description = cardDescriptions[1];

        playerCards[2].GetComponent<CardScript>().cardType = cardTypes[2];
        playerCards[2].GetComponent<CardScript>().description = cardDescriptions[2];
    }

    void updateCards()
    {
        foreach (GameObject obj in playerCards)
        {
            Destroy(obj);
        }

        playerCards.Clear();
        GeneratePlayerCards();
        InitializeCards();
    }
}
