using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Configuration.Assemblies;

///--------------------------------
///   Author: Victor Alvarez, Ph.D.
///   University of Oviedo, Spain
///--------------------------------

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    public string goal1 ="Pistola";
    public GameObject nGun;
    public GameObject model;
    public Camera camera;
    public Transform gunPoint;

    public Component c;


    private bool reach = false;

    Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
            velocity.y = Mathf.Sqrt (jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
      if (hit.gameObject.CompareTag(goal1) && !reach)
        {
          nGun.transform.position= gunPoint.position;
          nGun.transform.rotation=gunPoint.rotation;
          nGun.transform.parent = camera.transform;
          reach = true;
        }
      
}
}