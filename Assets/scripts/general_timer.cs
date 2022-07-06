using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class general_timer : MonoBehaviour
{
    public InputActionReference toggleReference = null;
    public bool isActive = false;

    // Start is called before the first frame update
    private void Awake()
    {
        toggleReference.action.started += Toggle;
    }

    // Update is called once per frame
    private void onDestroy()
    {
        toggleReference.action.started -= Toggle;
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        isActive = !isActive;
        gameObject.GetComponent<Image>().enabled = isActive;
    }
}
