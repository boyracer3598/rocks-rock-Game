using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public InputActionReference toggleMenuAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        toggleMenuAction.action.Enable();
        toggleMenuAction.action.performed += ToggleMenu;
    }

    void ToggleMenu(InputAction.CallbackContext context)
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
    }

    public void ToggleMenu()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
    }

    private void OnDestroy()
    {
        toggleMenuAction.action.Disable();
    }
    // Update is called once per frame
    void Update()
    { }
        
}
