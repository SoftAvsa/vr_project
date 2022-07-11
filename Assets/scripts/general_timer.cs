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
    // Timer activation flag
    public bool isActive = false;
    // Timer variable
    private float timer = 0;
    // Previous activation flag
    private bool wasActive = false;
    // Head tracking flag
    public bool lookAtScreen = false;
    // Focused time variable
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
        // If timer has been activated
        if (isActive)
        {
            timer += Time.deltaTime;
            // If timer is active and the user is looking at the screen
            if (lookAtScreen)
            {
                screenTimer += Time.deltaTime;
            }
        }
    }

    // Toggle action for the right controller trigger
    private void Toggle(InputAction.CallbackContext context)
    {
        // Activate/Deactivate timer
        isActive = !isActive;
        // Enable timer indicator
        gameObject.GetComponent<Image>().enabled = isActive;
        // If the timer was previously active and was now deactivated
        if (wasActive)
        {
            // Create directory for results
            if (!Directory.Exists(Application.streamingAssetsPath + "/ExperimentLogs/"))
            {
                Directory.CreateDirectory(Application.streamingAssetsPath + "/ExperimentLogs/");
            }
            // Create file with results
            DateTime current_time = DateTime.Now;
            string filename = current_time.ToString("dd-MM-yy_HH-mm-ss");
            Scene scene = SceneManager.GetActiveScene();
            string docName = Application.streamingAssetsPath + "/ExperimentLogs/exp_" + filename + ".txt";
            float focusedPercentage = (float)System.Math.Round((screenTimer / timer) * 100, 2);
            if (!File.Exists(docName))
            {
                File.WriteAllText(docName, "Experiment Results \n");
                File.AppendAllText(docName, "Scene: " + scene.name + "\n");
                File.AppendAllText(docName, "Total time: " + timer + "\n");
                File.AppendAllText(docName, "Time spent looking at screen: " + screenTimer + "\n");
                File.AppendAllText(docName, "Focused time: " + focusedPercentage + "%");
            }

        }
        wasActive = !wasActive;
    }

    // Set flag for head tracking
    public void SetLookFlag()
    {
        lookAtScreen = true;
    }

    public void RemoveLookFlag()
    {
        lookAtScreen = false;
    }
}
