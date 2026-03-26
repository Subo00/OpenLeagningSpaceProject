using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject game_ui;
    public GameObject win_message;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            game_ui.SetActive(false);
            win_message.SetActive(true);
            GetComponent<Collider>().enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        win_message.SetActive(false);
    }
}
