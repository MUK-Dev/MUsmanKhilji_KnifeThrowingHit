using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    //* Game Over UI
    public static GameOverUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Hide();
    }

    public void Hide() => gameObject.SetActive(false);
    public void Show() => gameObject.SetActive(true);
}
