using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuSystem : MonoBehaviour
{
    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider vomuleSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;

    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;

    [Header("Levels To Load")]
    public string _newGameLevel;
    private string levelToLoad;
    [SerializeField]
    private GameObject _noSaveGameDialog = null;

    public void NewGameDialogYes() 
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void LoadGameDialogYes() 
    {
        if (PlayerPrefs.HasKey("SavedLevel")) 
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevels");
            SceneManager.LoadScene(levelToLoad);
        }
        else {
            _noSaveGameDialog.SetActive(true);
        }
    }

    public void ExitButton() 
    {
        Application.Quit();
    }
}
