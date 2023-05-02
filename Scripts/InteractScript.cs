using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour

{
    public float interactDistance = 5f;
    public Inventory inventory;
    public float interactHeight=1.5f;
   public Text messageUI;
    void Update()
    {
       Debug.DrawRay(new Vector3(transform.position.x,interactHeight,transform.position.z), transform.forward*interactDistance, Color.green);

        
            Ray ray = new Ray(new Vector3(transform.position.x,interactHeight,transform.position.z), transform.forward);
            RaycastHit hit; 

            if(Physics.Raycast(ray, out hit, interactDistance))
            {
            Debug.Log(this.name+" Interact Script"+ hit.collider.name+" "+(hit.collider.GetComponent<ColliderMessage>()!=null));

                  if (hit.collider.TryGetComponent<ColliderMessage>(out ColliderMessage messageScript))
                      {
                // messageScript.active = true;
                if (messageUI != null)
                {
                    messageUI.text = messageScript.messageText;
                }
                    }else
                    {
                       
                    }

                if(hit.collider.CompareTag("Door"))
                {
                    if(Input.GetKeyDown(KeyCode.F))
                     {

                    DoorScript doorScript = hit.collider.GetComponent<DoorScript>();
                  
                    Debug.Log("Door Key" + (inventory.keys[doorScript.index]));


                    if (doorScript == null) return;
                        if(inventory.keys[doorScript.index] == true)
                        {
                         doorScript.ChangeDoorState();
                        }
                    }
                }
                else if(hit.collider.CompareTag("Key"))
                {
                      if(Input.GetKeyDown(KeyCode.F))
                      {
                        Debug.Log("Found Key"+  (inventory.keys[hit.collider.GetComponent<Key>().index]));
                    inventory.keys[hit.collider.GetComponent<Key>() .index] = true;
                         Destroy(hit.collider.gameObject);
                        
                      }
                

                }

            }else{

            if (messageUI != null)
            {
                messageUI.text = "";
            }
                 
            }

                
            
        
            
            
    }
    
}
