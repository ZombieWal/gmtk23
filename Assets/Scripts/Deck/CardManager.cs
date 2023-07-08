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

    public List<string> cardTypes = new List<string> { "character", "equipment", "spell" };
    public List<string> cardDescriptions = new List<string> { "Fight the opponent!", "Boost your damage!", "Do something!" };

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
        if (isRoundFinished)
        {
            updateCards();
        } 
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
        for(int i = 0; i < 3; i++)
        {
            playerCards[i].GetComponent<CardScript>().cardType = cardTypes[0];
            playerCards[i].GetComponent<CardScript>().description = cardDescriptions[0];
        }
    }

    void updateCards()
    {
        foreach (GameObject obj in playerCards)
        {
            Destroy(obj);
        }

        playerCards.Clear();
        GeneratePlayerCards();
    }
}
