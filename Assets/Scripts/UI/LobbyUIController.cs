using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LobbyUIController : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button QuitButton;

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitButtonPressed()
    {
       Application.Quit();
    }
}
