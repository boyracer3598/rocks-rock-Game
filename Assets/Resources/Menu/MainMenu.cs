using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    
    public GameObject mainMenu;
    public InputActionReference toggleMenuAction;
    public Slider LightLevelSlider;
    public Slider voluneSlider;
    public Volume PostProcessing;
    public float lightLevel = 0.5f;
    public float volumeLevel = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        toggleMenuAction.action.Enable();
        toggleMenuAction.action.performed += ToggleMenu;
        LightLevelSlider.value = lightLevel;
        voluneSlider.value = volumeLevel;

        // Add listeners to the sliders to update the light and volume levels when they are changed
        LightLevelSlider.onValueChanged.AddListener(delegate { LightLevelChange(); });
        voluneSlider.onValueChanged.AddListener(delegate { VolumeLevelChange(); });
        audioMixer.SetFloat("Volume", Mathf.Log10(PlayerPrefs.GetFloat("Volume", 1)) * 20);// Set the initial volume level based on saved preferences
    }

    void ToggleMenu(InputAction.CallbackContext context)
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
    }

    public void LightLevelChange()
    {
        lightLevel = LightLevelSlider.value;
        PostProcessing.weight = 1-lightLevel;
    }

    public void VolumeLevelChange()
    {
        volumeLevel = voluneSlider.value;
        audioMixer.SetFloat("Volume", Mathf.Log10(volumeLevel) * 20);
        PlayerPrefs.SetFloat("Volume", volumeLevel); // Save the volume level to player preferences
        PlayerPrefs.Save(); // Save the player preferences to disk
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
