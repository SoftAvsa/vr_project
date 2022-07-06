using System;
using System.IO;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class general_timer : MonoBehaviour
{
    public InputActionReference toggleReference = null;
    public bool isActive = false;
    [HideInInspector]
    public float timer = 0;
    [HideInInspector]
    public bool wasActive = false;

    private void Awake()
    {
        toggleReference.action.started += Toggle;
    }

    private void onDestroy()
    {
        toggleReference.action.started -= Toggle;
    }

    void Update()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
        }
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        isActive = !isActive;
        gameObject.GetComponent<Image>().enabled = isActive;
        if (wasActive)
        {
            DateTime current_time = DateTime.Now;
            Scene scene = SceneManager.GetActiveScene();
            string docName = "ExperimentLogs/" + current_time + ".txt";
            if (!File.Exists(docName))
            {
                File.WriteAllText(docName, "Experiment Results \n");
                File.WriteAllText(docName, scene.name + "\n");
                File.WriteAllText(docName, timer + "\n");
            }

        }
        wasActive = !wasActive;
    }
}
