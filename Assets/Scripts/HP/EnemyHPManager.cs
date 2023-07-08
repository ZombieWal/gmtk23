using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPManager : MonoBehaviour
{
    public int enemyHpCount;

    // Start is called before the first frame update
    void Start()
    {
        showHPBar();
    }

    // Update is called once per frame
    void Update()
    {
        clearHPBar();
        showHPBar();
    }

    void showHPBar()
    {

    }

    void clearHPBar()
    {

    }
}
