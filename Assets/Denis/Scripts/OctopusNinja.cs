using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OctopusNinja : MonoBehaviour
{
    public float spawnTime;

    public GameObject blade;

    public TMP_Text textForceBlow;
    public float forceBlow = 0f;

    private bool isNinjaGame;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



        if (isNinjaGame)
        {
            textForceBlow.text = "FORCE BLOW:" + forceBlow.ToString("#%");
            if(forceBlow > 1)
                textForceBlow.color = new Color32(241, 24, 34, 255);
        }


    }

    public void StartOctopusNinja()
    {
        StartCoroutine(EndOctopusNinja());
        GetComponentInChildren<OctopusSpawner>().SpawnOctopus(spawnTime);
        blade.GetComponent<Blade>().StartCutting();
        isNinjaGame = true;
    }


    IEnumerator EndOctopusNinja()
    {
        yield return new WaitForSeconds(spawnTime + 3);
        blade.GetComponent<Blade>().StopCutting();
        isNinjaGame = false;
        textForceBlow.text = "";
        if(forceBlow < 1)
            FindObjectOfType<FightController>().DealDamage(20);
        else if(forceBlow >= 1)
            FindObjectOfType<FightController>().DealDamage(40);
        forceBlow = 0;

        FindObjectOfType<CardScript>().StartFightF();
    }
}