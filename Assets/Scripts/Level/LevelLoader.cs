using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private string LevelName;

    [SerializeField]
    private LevelSelectController levelSelectObject;

    void Start()
    {
        button.onClick.AddListener(onClickLevelButton);
    }

    private void onClickLevelButton()
    {
        levelSelectObject.setLevelToPlay(LevelName);
    }

    public string getLevelName()
    {
        return LevelName;
    }
}
