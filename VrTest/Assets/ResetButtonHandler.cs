using UnityEngine;
using UnityEngine.InputSystem;

public class ResetButtonHandler : MonoBehaviour
{
    private InputAction aButtonAction;

    private void OnEnable()
    {
        // Get a reference to the existing InputAction "XRI_Right_PrimaryButton"
        aButtonAction = new InputAction("XRI_Right_PrimaryButton", InputActionType.Button);

        // Enable the input action
        aButtonAction.Enable();

        // Subscribe to the button press event
        aButtonAction.started += OnAButtonPressed;
    }

    private void OnDisable()
    {
        // Disable the input action and unsubscribe from the event
        aButtonAction.Disable();
        aButtonAction.started -= OnAButtonPressed;
    }

    private void OnAButtonPressed(InputAction.CallbackContext context)
    {
        // Put your code here to execute when the A button is pressed
        Debug.Log("A button pressed!");

        GameObject sphere= GameObject.FindGameObjectsWithTag("Sphere")[0];
        Respawn sphereRespawn = sphere.GetComponent<Respawn>();
        sphereRespawn.RestoreBall();

    }
}
