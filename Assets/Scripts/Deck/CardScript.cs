using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CardScript : MonoBehaviour
{
    public string cardType;
    public string description;
    public Image cardImage;
    public TMP_Text cardDescription;
    public Button button;
    public GameObject playerHand;
    public GameObject fightController;

    private void Start()
    {
        playerHand = GameObject.Find("Player Hand");
        fightController = GameObject.Find("FightController");
    }

    private void Awake()
    {
        button.onClick.AddListener(OnButtonClick);
        
    }

    void OnButtonClick()
    {
        StartCoroutine(playerHand.GetComponent<HandMovement>().PlaceCard(gameObject, new Vector3(0.0f, -2.6f, 0.0f)));

        if (cardType == "character")
        {   
            fightController.GetComponent<FightController>().StartFight();
        }
    }

    // Update is called once per frame
    void Update()
    {
        cardDescription.text = description;
    }
}
