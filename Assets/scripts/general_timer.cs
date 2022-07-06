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
    private float timer = 0;
    private bool wasActive = false;
    public bool lookAtScreen = false;
    private float screenTimer = 0;

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
            if (lookAtScreen)
            {
                screenTimer += Time.deltaTime;
            }
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
                File.AppendAllText(docName, "Scene: " + scene.name + "\n");
                File.AppendAllText(docName, "Total time: " + timer + "\n");
                File.AppendAllText(docName, "Focused time: " + screenTimer);
            }

        }
        wasActive = !wasActive;
    }

    public void SetLookFlag()
    {
        lookAtScreen = true;
    }

    public void RemoveLookFlag()
    {
        lookAtScreen = false;
    }
}
