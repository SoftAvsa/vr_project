using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class general_timer : MonoBehaviour
{
    List<UnityEngine.XR.InputDevice> inputDevices = new List<UnityEngine.XR.InputDevice>();
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var device in inputDevices)
        {
            Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.characteristics.ToString()));
        }
    }
}
