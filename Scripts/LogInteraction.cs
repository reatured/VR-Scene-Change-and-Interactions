using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LogInteraction : MonoBehaviour
{
    public void LogHoverEnter(XRBaseInteractor interactor)
    {
        Debug.Log(gameObject.name + "Hover Enter by: " + interactor.gameObject.name);
    }

    //cpp;
}
