using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using static UnityEditor.FilePathAttribute;
using Kay.Data;
using UnityEngine.InputSystem;
using System;
public class BackpackFunction : MonoBehaviour
{
    public InputActionReference grabAction;
    private bool isInBag = false;
    public KayStack<string> objects = new KayStack<string>();
    void Start()
    {
        //set up inputs
        grabAction.action.Enable();
        grabAction.action.performed += Grab;
    }

    private void OnDestroy()
    {
        grabAction.action.Disable();
    }

    void Grab(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           if(isInBag)
            {
                RemoveRock();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            isInBag = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("its a trigger  "+ other.gameObject.tag+ other.gameObject.name);



        // putting a rock into the bag
        if (other.gameObject.CompareTag("Rock"))
        {
            string rock = other.gameObject.GetComponent<Rock>().RockName;
            objects.Append(rock);
            Destroy(other.gameObject);
            // grabing a rock out of the bag
        }
        else if (other.gameObject.CompareTag("Hand"))
        {
            isInBag = true;
            Debug.Log("grabing from bag");
        }
    }
    public void RemoveRock()
    {
        if (objects.Size() > 0)
        {
            GameObject newRock = (GameObject)Instantiate(Resources.Load("rock pickup"));
            newRock.GetComponent<Rock>().fileName = (string)objects.Pop();
            newRock.GetComponent<Rock>().Refresh();
        }
    }
    public void RemoveRock(int location)
    {
        GameObject newRock = (GameObject)Instantiate(Resources.Load("rock pickup"));
        newRock.GetComponent<Rock>().fileName = (string)objects.Remove(location);
        newRock.GetComponent<Rock>().Refresh();
    }
    public void EmptyBag()
    {
        for (int i = 0; i < objects.Size(); i++)
        {
            GameObject newRock = (GameObject)Instantiate(Resources.Load("rock pickup"));
            newRock.GetComponent<Rock>().fileName = (string)objects.Stab();
            newRock.GetComponent<Rock>().Refresh();
        }
    }
}
