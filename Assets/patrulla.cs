using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class patrulla : MonoBehaviour
{


    public float patrolspeed = 0f;
    public float changeTargetDistance = 0.1f;

    public Transform[] patrolpoints;

    int curretTarget = 0;

    public TextMeshProUGUI dificultad;

    void Start()
    {
        curretTarget = Random.Range(0, 9);
        transform.position = patrolpoints[curretTarget].position;

        if (dificultad.text == "Facil")
            patrolspeed = 5f;
        else if (dificultad.text == "Normal")
            patrolspeed = 7f;
        else
            patrolspeed = 9f;
    }

    void Update()
    {
        if (MoveToTarget())
        {
            curretTarget = GetNextTarget();

        }
    }

    private bool MoveToTarget()
    {
        Vector3 distanciavector = patrolpoints[curretTarget].position - transform.position;
        if (distanciavector.magnitude < changeTargetDistance)
        {

            return true;
        }

        Vector3 velocityVector = distanciavector.normalized;
        transform.position += velocityVector * patrolspeed * Time.deltaTime;

        return false;
    }

    private int GetNextTarget()
    {

        curretTarget++;
        if(curretTarget >= patrolpoints.Length)
        {
            curretTarget = 0;
        }
        return curretTarget;
    }
}
