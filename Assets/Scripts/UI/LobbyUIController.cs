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

    void Start()
    {
        playButton.onClick.AddListener(StartGameplay);
        QuitButton.onClick.AddListener(QuitGame);

    }

    public void StartGameplay()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
       Application.Quit();
    }
}
