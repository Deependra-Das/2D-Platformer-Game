using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;

    [SerializeField]
    private string LevelName;

    LevelSelectController levelSelectObject;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClickLevelButton);

        levelSelectObject =  GameObject.Find("LevelSelectorPanel").GetComponent<LevelSelectController>();
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
