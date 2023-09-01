using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerChoise : MonoBehaviour
{
    public Canvas a;
    public Canvas b;
    public GameObject sharedObject;
    public void ForKeyboard()
    {
        sharedObject.GetComponent<ControllerForPC>().gameObject.SetActive(true);
        a.gameObject.SetActive(true);
        b.gameObject.SetActive(false);
    }
    public void ForMobileDevice()
    {
        sharedObject.GetComponent<ControllerForPhone>().gameObject.SetActive(true);
        a.gameObject.SetActive(true);
        b.gameObject.SetActive(false);
    }
    
}
