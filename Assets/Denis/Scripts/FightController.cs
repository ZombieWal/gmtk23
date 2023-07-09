using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FightController : MonoBehaviour
{
    public GameObject playerPoint;
    public GameObject player;

    public int curremtPointIndex = 0;
    public GameObject[] spawnPoints;

    public float fightTimer;
    public TMP_Text time_;
    public GameObject restart;

    public GameObject enemy;
    public GameObject[] enemies;
    public bool endOfFight = true;

    public bool j = false;
    public bool y = false;
    // Start is called before the first frame update
    void Start()
    {
        time_.text = "";
    }

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player_ = GameObject.FindGameObjectWithTag("Player");
        if (player_ == null)
        {
            if (j)
            { 
                  restart.SetActive(true);
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);


                }
            }
            else
            {
                restart.SetActive(false);
            }
        }
        else
        {
            restart.SetActive(false);
        }


        if (!endOfFight)
        {

                fightTimer -= Time.deltaTime;
                if (fightTimer < 0)
                {
                    EndFight();
                }

            if (time_ != null)
            {
                if (fightTimer > 0)
                    time_.text = "Time: " + fightTimer.ToString("#.0");
                else
                    time_.text = "Time: " + "0,0";
            }
        }
        else
            time_.text = "";
        var enemyNumber_ = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyNumber_.Length <= 0)
        {
            Invoke("Win", 0.2f);
        }



    }

    public void StartFight()
    {
        y = true;
        GameObject player_ = GameObject.FindGameObjectWithTag("Player");

        endOfFight = false;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy_ in enemies)
        {
            enemy_.GetComponent<EnemyMove>().start_ = true;
            enemy_.GetComponent<EnemyAttacking>().start_ = true;
            if (player_ != null)
            {
                enemy_.GetComponent<EnemyMove>().target = player_.transform;
                enemy_.GetComponent<EnemyAttacking>().target = player_.transform;
            }
        }

        if (player_ != null)
        {
            player_.GetComponent<PlayerMovement>().start_ = true;
        }
    }

    public void SpawnNewEnemy(GameObject enemy)
    {
        if (spawnPoints.Length >= curremtPointIndex)
        {
            GameObject curremtPoint = spawnPoints[curremtPointIndex];
            Instantiate(enemy, curremtPoint.transform.position, curremtPoint.transform.rotation);
            curremtPointIndex++;
        }
    }

    public void SpawnNewPlayer()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject newPlayer_ = Instantiate(player, playerPoint.transform.position, playerPoint.transform.rotation);
        var i = 0;
        foreach (GameObject enemy_ in enemies)
        {
            enemy_.GetComponent<EnemyMove>().target = newPlayer_.transform;
            enemy_.GetComponent<EnemyAttacking>().target = newPlayer_.transform;
            i++;
        }
    }

    public void DealDamage(float damage)
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        var i = 0;
        foreach (GameObject enemy_ in enemies)
        {
            enemy_.GetComponent<Health>().Damage(damage);
            i++;
        }
    }

    public void Win()
    {
        EndFight();
    }

    public void RIP()
    {
        EndFight();
        
    }

    public void EndFight()
    {
        j = true;
        //SpawnNewEnemy(enemy);
        time_.text = "";
        endOfFight = true;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        var i = 0;
        foreach (GameObject enemy_ in enemies)
        {
            enemy_.transform.position = spawnPoints[i].transform.position;
            enemy_.GetComponent<EnemyMove>().start_ = false;
            enemy_.GetComponent<EnemyAttacking>().start_ = false;
            i++;
        }

        GameObject player_ = GameObject.FindGameObjectWithTag("Player");
        if (player_ != null)
        {
            player_.transform.position = playerPoint.transform.position;
            player_.GetComponent<PlayerMovement>().start_ = false;
        }

    }
}