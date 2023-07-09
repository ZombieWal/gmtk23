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
    public GameObject rhythmGameController;
    public GameObject octopusNinja;
    public GameObject enemy;
    public GameObject tooltip;
    public bool isPlaced = false;

    private void Start()
    {
        playerHand = GameObject.Find("Player Hand");
        fightController = GameObject.Find("FightController");
        rhythmGameController = GameObject.Find("RhythmGameController");
        octopusNinja = GameObject.Find("OctopusNinja");
        //tooltip = GameObject.Find("Tooltip");

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
            StartCoroutine(StartFight(2.0f, true, 2));
        }

        if (cardType == "lute")
        {
            StartCoroutine(StartRhythmGame(2.0f));
        }

        if (cardType == "ninja")
        {
            StartCoroutine(StartNinjaGame(2.0f));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        cardDescription.text = description;

        if(isPlaced && !fightController.GetComponent<FightController>().endOfFight && playerHand.GetComponent<HandMovement>().isReturned == true)
        {
            Destroy(gameObject);
            //StartCoroutine(ShowTooltip(0.1f));
        }

        if (isPlaced && RhythmGameManager.instance.isActive && playerHand.GetComponent<HandMovement>().isReturned)
        {
            Destroy(gameObject);
        }

        //add smth on win-loose state for both ninja and rhythm game
    }

    public void StartFightF()
    {
        StartCoroutine(StartFight(2.0f, false, 0));
    }

    IEnumerator StartFight(float duration, bool player_, int enemys_)
    {
        yield return new WaitForSeconds(duration);
        if(player_)
            fightController.GetComponent<FightController>().SpawnNewPlayer();

        for (int i = 0; i < enemys_; i++)
        {
            fightController.GetComponent<FightController>().SpawnNewEnemy(enemy);
        }

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

    IEnumerator StartRhythmGame(float duration)
    {
        yield return new WaitForSeconds(duration);

        rhythmGameController.GetComponent<RhythmGameController>().StartRhythmGame();
    }

    IEnumerator ShowTooltip(float duration)
    {
        tooltip.GetComponent<TMP_Text>().text = "Rolls reversed!";
        yield return new WaitForSeconds(duration);
        tooltip.GetComponent<TMP_Text>().text = "";
    }

    IEnumerator StartNinjaGame(float duration)
    {
        yield return new WaitForSeconds(duration);

        octopusNinja.GetComponent<OctopusNinja>().StartOctopusNinja();

        //call for game start
    }
}
