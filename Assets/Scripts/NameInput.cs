using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.Instance.playerName != null)
        {
            GetComponent<InputField>().text = MainManager.Instance.playerName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
