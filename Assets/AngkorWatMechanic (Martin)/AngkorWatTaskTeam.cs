using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngkorWatTaskTeam : MonoBehaviour
{

    [SerializeField]
    GameObject target;

    [SerializeField]
    int takeOverTime;

    [SerializeField]
    float timer;
    [SerializeField]
    bool takingOver;

    private void Start() {
        timer = takeOverTime;
    }

    private void Update() {
        // Attack / Assassinate city
        if(Input.GetKeyDown(KeyCode.A) && !takingOver)
        {
            target = GameObject.FindGameObjectWithTag("EnemyBase");

            if (target != null)
            {
                takingOver = true;
            }
        }

        if(takingOver)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                takingOver = false;
                target.GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }

        
    }

}
