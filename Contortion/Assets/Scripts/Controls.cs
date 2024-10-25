using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controls : MonoBehaviour
{
    public TextMeshProUGUI control_text;
    private static bool controlsShown = false;

    void Start()
    {
        if (!controlsShown)
        {
            StartCoroutine(ShowControls());
            controlsShown = true;
        }
        else
        {
            control_text.text = "";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StopCoroutine(ShowControls());
            control_text.text = "";
        }
    }

    IEnumerator ShowControls()
    {
        control_text.text = "F to flip\nA/S or Left/Right Arrow keys to move";
        yield return new WaitForSeconds(3);
        control_text.text = "";
    }
}