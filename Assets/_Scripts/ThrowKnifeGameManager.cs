using UnityEngine;

public class ThrowKnifeGameManager : MonoBehaviour
{
    //* This is just checking if game is over or not
    public static ThrowKnifeGameManager Instance { get; private set; }
    private bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
    }

    public void FinishGame() => isGameOver = true;

    public bool IsGameOver() => isGameOver;
}
