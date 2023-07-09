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
    public GameObject enemy;
    public bool isPlaced = false;

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
        isPlaced = true;

        if (cardType == "character")
        {
            StartCoroutine(StartFight(2.0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        cardDescription.text = description;
    }

    IEnumerator StartFight(float duration)
    {
        yield return new WaitForSeconds(duration);

        fightController.GetComponent<FightController>().SpawnNewPlayer();
        fightController.GetComponent<FightController>().SpawnNewEnemy(enemy);
        fightController.GetComponent<FightController>().SpawnNewEnemy(enemy);

        yield return new WaitForSeconds(0.2f);

        fightController.GetComponent<FightController>().StartFight();
    }

    IEnumerator CheckFightEnd()
    {
        yield return new WaitForSeconds(2.0f);

        if (fightController.GetComponent<FightController>().endOfFight && isPlaced)
        {
            StartCoroutine(playerHand.GetComponent<HandMovement>().RemoveCard(gameObject));
        }
    }
}
