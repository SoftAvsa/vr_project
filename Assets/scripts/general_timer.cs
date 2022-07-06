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
            if (!Directory.Exists(Application.streamingAssetsPath + "/ExperimentLogs/"))
            {
                Directory.CreateDirectory(Application.streamingAssetsPath + "/ExperimentLogs/");
            }
            DateTime current_time = DateTime.Now;
            string filename = current_time.ToString("dd-MM-yy_HH-mm-ss");
            Scene scene = SceneManager.GetActiveScene();
            string docName = Application.streamingAssetsPath + "/ExperimentLogs/exp_" + filename + ".txt";
            if (!File.Exists(docName))
            {
                File.WriteAllText(docName, "Experiment Results \n");
                File.AppendAllText(docName, scene.name + "\n");
                File.AppendAllText(docName, timer + "\n");
            }

        }
        wasActive = !wasActive;
    }
}
