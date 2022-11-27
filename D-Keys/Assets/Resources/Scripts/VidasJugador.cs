using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class VidasJugador : MonoBehaviour
{

    private static int Vidas;
    public Image Corazon1;
    public Image Corazon2;
    public Image Corazon3;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.vidas >= 3){
            GameController.vidas = 3;
        }else if(GameController.vidas == 2){
            Corazon3.color = Color.black;
        }else if(GameController.vidas == 1){
            Corazon2.color = Color.black;
            Corazon3.color = Color.black;
        }else if(GameController.vidas == 0){
            SceneManager.LoadScene("the last revelation");
        }

    }
 
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Lava"){
            GameController.vidas -= 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
