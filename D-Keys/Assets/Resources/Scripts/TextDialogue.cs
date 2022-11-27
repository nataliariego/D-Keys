using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using System.Configuration.Assemblies;

// IMPORTANT: This Script is a component of the PLAYER
// It includes two NPCs and conversations, adapt it to the number of NPCs and conversations in your scene.
// Change: Class properties and methods OnTriggerEnter and OnTriggerExit.

///--------------------------------
///   Author: Victor Alvarez, Ph.D.
///   University of Oviedo, Spain
///--------------------------------

public class TextDialogue : MonoBehaviour
{
    // * Class properties for two NPCs and conversations *
    public string NPC1Tag, NPC2Tag, NPC3Tag, NPC41Tag, NPC42Tag, NPC5Tag, NPC6Tag;
    public NPCConversation NPC1Conversation, NPC2Conversation, NPC3Conversation, NPC4Conversation, NPC5Conversation, NPC6Conversation;

    private float sensitivity = 0.18f;
    private float axisTimer, verticalAxis = 0f;

    public bool yaShelf1, yaShelf2 = false;

    public bool yaFuiMesa1, yaFuiPecera, yaFuiLavabo, yaFuiMesa2, yaFuiJeringuilla= false;

    public int orden = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if ((ConversationManager.Instance != null) & (ConversationManager.Instance.IsConversationActive))
        {
            verticalAxis = Input.GetAxis("Vertical");

            if (axisTimer >= sensitivity)
                axisTimer = 0;

            if ((axisTimer == 0) & (verticalAxis > 0))
            {
                ConversationManager.Instance.SelectPreviousOption();
            }
            else if ((axisTimer == 0) & (verticalAxis < 0))
            {
                ConversationManager.Instance.SelectNextOption();
            }
            else if (Input.GetAxis("Fire1") == 1)
            {
                ConversationManager.Instance.PressSelectedOption();
                axisTimer = 0;
                return;
            }

            axisTimer += Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        // * Starts conversation for two NPCs 

        if (collider.gameObject.CompareTag(NPC1Tag) && !yaFuiMesa1
            && orden==0)
        {
            orden++;
            yaFuiMesa1 = true;
            ConversationManager.Instance.StartConversation(NPC1Conversation);
        }

        if (collider.gameObject.CompareTag(NPC2Tag) && !yaFuiPecera && orden==1)
        {
            orden++;
            yaFuiPecera = true;

            ConversationManager.Instance.StartConversation(NPC2Conversation);
            Vector3 v = new Vector3(-5.2f, -0.6f, -8.945f);
            GameObject word1 = Instantiate(Resources.Load("Flask_06"), v, Quaternion.identity) as GameObject;
            word1.transform.localScale = new Vector3(2f, 2f, 2f);

            GameObject.Find("CuencoAcuario1").SetActive(false);
            
        }
        if (collider.gameObject.CompareTag(NPC3Tag) && !yaFuiLavabo && orden==2)
        {
            orden++;
            yaFuiLavabo = true;
            ConversationManager.Instance.StartConversation(NPC3Conversation);

            Vector3 v = new Vector3(-7.621858f, -0.346f, -9.2141f);
            GameObject word1 = Instantiate(Resources.Load("Flask_02"), v, Quaternion.identity) as GameObject;
            word1.transform.localScale = new Vector3(2f, 2f, 2f);

            GameObject.Find("Matraz2").SetActive(false);
        }
        if (collider.gameObject.CompareTag(NPC41Tag) && !yaShelf1 &&
            (orden==3 || orden==4)) {
            orden++;
            yaShelf1 = true;
            Vector3 v = new Vector3(-5.874f, -0.6f, -8.97f);
            GameObject word1 = Instantiate(Resources.Load("Flask_05"), v, Quaternion.identity) as GameObject;
            word1.transform.localScale = new Vector3(2f, 1f, 2f);

            GameObject.Find("Sustancia1").SetActive(false);
            if (yaShelf2 == true)
            {
                ConversationManager.Instance.StartConversation(NPC4Conversation);

                
            }
        }
        if (collider.gameObject.CompareTag(NPC42Tag) && !yaShelf2 &&
            (orden == 3 || orden == 4))
        {
            orden++;
            yaShelf2 = true;
            Vector3 v = new Vector3(-6.424f, -0.6f, -8.97f);
            GameObject word1 = Instantiate(Resources.Load("Flask_04"), v, Quaternion.identity) as GameObject;
            word1.transform.localScale = new Vector3(2f, 2f, 2f);

            GameObject.Find("Sustancia2").SetActive(false);
            if (yaShelf1 == true) {
                ConversationManager.Instance.StartConversation(NPC4Conversation);

                
            }
        }

        if (collider.gameObject.CompareTag(NPC5Tag) && !yaFuiMesa2 && orden==5)
        {
            orden++;
            yaFuiMesa2 = true;
            ConversationManager.Instance.StartConversation(NPC5Conversation);
           
        }
        if (collider.gameObject.CompareTag(NPC6Tag) && !yaFuiJeringuilla && orden==6)
        {
            orden++;
            yaFuiJeringuilla = true;
            ConversationManager.Instance.StartConversation(NPC6Conversation);
            GameObject.Find("Jeringuilla").SetActive(false);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        // * Ends conversation for two NPCs 

        if (collider.gameObject.CompareTag(NPC1Tag) || collider.gameObject.CompareTag(NPC2Tag)
            || collider.gameObject.CompareTag(NPC3Tag) || collider.gameObject.CompareTag(NPC41Tag)
            || collider.gameObject.CompareTag(NPC42Tag)
            || collider.gameObject.CompareTag(NPC5Tag)
            || collider.gameObject.CompareTag(NPC6Tag))
        {
            ConversationManager.Instance.EndConversation();
        }
    }
}
