using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionUI : MonoBehaviour
{
    //* Change levels
    private enum Scenes
    {
        First,
        Second,
        Third
    }
    [SerializeField] private Button first;
    [SerializeField] private Button second;
    [SerializeField] private Button third;

    private void Start()
    {
        first.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(Scenes.First.ToString());
        });
        second.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(Scenes.Second.ToString());
        });
        third.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(Scenes.Third.ToString());
        });
    }
}
