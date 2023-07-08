using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<GameObject> playerCards = new List<GameObject>();
    private GameObject newCard;
    public GameObject card;
    public bool isRoundFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePlayerCards();
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
