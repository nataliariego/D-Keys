using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

///--------------------------------
///   Author: Victor Alvarez, Ph.D.
///   University of Oviedo, Spain
///--------------------------------

public class Chase : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        // initialise NavMeshAgent position on NavMesh
        enemy.Warp(enemy.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        enemy.transform.LookAt(Player.position);
        enemy.GetComponent<Animator>().Play("walk");
        enemy.SetDestination(Player.position);
    }
}
