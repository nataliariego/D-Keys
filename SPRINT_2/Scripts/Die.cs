using System;
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
    private Boolean die=false;
    private int shots =0;
    // Start is called before the first frame update
    void Start()
    {
        // initialise NavMeshAgent position on NavMesh
        enemy.Warp(enemy.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(!die){
            enemy.transform.LookAt(Player.position);
            enemy.GetComponent<Animator>().Play("walk");
            enemy.SetDestination(Player.position);
        }
        
    }

    public void OnControllisionEnter(Collision collision)
    {
      if (collision.gameObject.tag.Equals("Bala") && !die)
        {
          //No consigo que detecte la colision
          Debug.Log("tocado");
          shots++;
          if(shots == 3){
            die =true;
          }
        }
      
}
}