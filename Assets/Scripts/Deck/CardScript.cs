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

    private void Awake()
    {
        button.onClick.AddListener(OnButtonClick);
        
    }

    void OnButtonClick()
    {
        if (cardType == "character")
        {
            StartFight();
        }
    }

    // Update is called once per frame
    void Update()
    {
        cardDescription.text = description;
    }

    //delete me later
    void StartFight()
    {

    }
}
