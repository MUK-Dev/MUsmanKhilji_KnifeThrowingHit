using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenuUI : MonoBehaviour
{
    //* Returns to level selection
    public void ReturnToLevel()
    {
        SceneManager.LoadScene("Levels");
    }
}
