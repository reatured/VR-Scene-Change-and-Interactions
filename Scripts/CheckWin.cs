using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckWin : MonoBehaviour
{
    public UnityEvent onWin = new UnityEvent();
    public GameObject winMessage;
    // Start is called before the first frame update
    void Start()
    {
        winMessage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            onWin?.Invoke();
            winMessage.SetActive(true);

        }
    }
}
