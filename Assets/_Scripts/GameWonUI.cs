using UnityEngine;

public class GameWonUI : MonoBehaviour
{
    //* Game won UI
    public static GameWonUI Instance { get; private set; }
    [HideInInspector] public bool isGameWon;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Hide();
    }

    public void Hide() => gameObject.SetActive(false);
    public void Show()
    {
        gameObject.SetActive(true);
        isGameWon = true;
    }
}
