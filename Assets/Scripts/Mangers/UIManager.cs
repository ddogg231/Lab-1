using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Button")]
    public Button startButton;
    public Button SettingsButton;
    public Button QuitButton;
    public Button ReturnToMainMenuButton;
    public Button ReturnToGameButton;

    [Header("Menu")]
    public GameObject mainMenu;
    public GameObject SettingsMenu;
    public GameObject pauseMenu;

    [Header("Text")]
    public Text volSliderText;
    public Text livesText;

    [Header("Slider")]
    public Slider volSlider;

    void StartGame()
    {
        SceneManager.LoadScene(1);

    }

    void ShowSettingMenu()
    {
        mainMenu.SetActive(false);
        SettingsMenu.SetActive(true);

        if (volSlider && volSliderText)
            volSliderText.text = volSlider.value.ToString();
    }    
    void ShowmainMenu()
    {
        if (SceneManager.GetActiveScene().name == "lab1")
        {
            SceneManager.LoadScene("title");
        }
        else
        {
            SettingsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }

    }

    void ResumeGame()
    {
        pauseMenu.SetActive(false);
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
    }


    void onValueChange(float value)
    {
        if (volSliderText)
            volSliderText.text = value.ToString();
    }


    void UpdateLifeText(int value)
    {
        livesText.text = value.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (startButton)
            startButton.onClick.AddListener(StartGame);

        if(SettingsButton)
        {
            SettingsButton.onClick.AddListener(ShowSettingMenu);
        }

        if (QuitButton)
        {
            QuitButton.onClick.AddListener(QuitGame);
        }

        if(volSlider)
        {
            volSlider.onValueChanged.AddListener(onValueChange);
        }

        if(ReturnToMainMenuButton)
        {
            ReturnToMainMenuButton.onClick.AddListener(ShowmainMenu);
        }

        if(ReturnToGameButton)
        {
            ReturnToGameButton.onClick.AddListener(ResumeGame);
        }

        if(livesText)
        {
            GameManager.Instance.onLifeValueChanged.AddListener(UpdateLifeText);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseMenu) return;

        if(Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            
            if(pauseMenu.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
}
