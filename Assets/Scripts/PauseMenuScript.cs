using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    private bool paused = false;
    // Reference to the Pause Menu Panel, so we can enable/disable it!
    public GameObject pauseMenuPanel;
    // Also reference the HUDPanel so we can toggle it with the above
    public GameObject scorePanel;

    // public state and References needed for lights managment
    public bool dayLight = true;
    public Button lightsOptionButton;
    public Light dayLightSource;
    public LampsControllerScript fieldLamps;

    // public state and References needed for controlling particle systems.
    public bool highDetailLevel = true;
    public Button detailsOptionButton;
    public ParticleSystem[] particleSystems;

    // References needed for getting/setting music levels.
    // Could be done as the above, but this works for now.
    public Slider musicVolumeSlider;
    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        // Start the game with the choosen settings!
        // Not really the best place to do it, but, for
        // all intents and purposes, it can demonstrate
        // how to set up a scene from a script, where the
        // actual options could have been loaded from 
        // for example a file or a scene configuration.
        UpdateLightSources();
        UpdateParticleSystems();
        pauseMenuPanel.SetActive(false);
        scorePanel.SetActive(true);
    }


    private void UpdateLightSources()
    {
        // If option is true, its daylight. option is true, !option is false.
        // If option is false, its nighttime. 
        dayLightSource.gameObject.SetActive(dayLight);
        fieldLamps.isOn = !dayLight;
    }

    private void UpdateParticleSystems()
    {
        // If highDetailLevel is true, particle systems will be on, but not if false.
        foreach (ParticleSystem ps in particleSystems)
        {
            ps.gameObject.SetActive(highDetailLevel);
        }
    }

    // Togglers for the two options. Used by the UI-buttons!
    public void ToggleLightsOption()
    {
        dayLight = !dayLight;
        // This type of inline if statement is called a Ternary! (condition) ? consequent : alternative
        lightsOptionButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text
            = (dayLight) ? "Lights: Day" : "Lights: Night";
        UpdateLightSources();
    }

    public void ToggleDetailLevelOption()
    {
        highDetailLevel = !highDetailLevel;
        detailsOptionButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text
            = (highDetailLevel) ? "Details: High" : "Details: Low";
        UpdateParticleSystems();
    }

    // Used by the slider!
    public void UpdateVolumeLevel()
    {
        musicSource.volume = musicVolumeSlider.value;

        // You can (voluntary free) try setting the text label
        // next to the slider to show the volume percentage! 
        // If so, you need to add a public TMPro.TextMeshProUGUI reference
        // above, and then (as in the toggleMethods above) change the text
        // to something suitable!
    }


    // Update is called once per frame
    void Update()
    {
        // If the player pushes escape, bring us into the pause menu!
        if (Input.GetKeyDown("escape"))
        {
            if (!paused)
            {
                Pause();
            }
            else
            {
                Resume();
            }

        }
    }

    //Handle pausing/unpausing
    // This gets called when the Esc key was hit through Update!
    public void Pause()
    {
        paused = true;
        // Freeze the game! (why does this actually work? what does it do?)
        Time.timeScale = 0.0f;

        // Get the current volume of background music!
        musicVolumeSlider.value = musicSource.volume;

        scorePanel.SetActive(false);
        //Activate the pause menu panel!
        pauseMenuPanel.SetActive(true);

    }

    public void Resume()
    {
        // This gets called when the player hits the Resume button!
        // This method should disable the panel, and start the timer again.
        // It should also bring back the score panel!
        pauseMenuPanel.SetActive(false);
        scorePanel.SetActive(true);

        // Unfreeze the game!
        paused = false;
        Time.timeScale = 1.0f;
    }
}