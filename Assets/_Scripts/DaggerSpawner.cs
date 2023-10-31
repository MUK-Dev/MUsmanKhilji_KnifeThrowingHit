using UnityEngine;

public class DaggerSpawner : MonoBehaviour
{
    public static DaggerSpawner Instance { get; private set; }

    [SerializeField] private GameObject daggerPrefab;

    //? Dagger held by the spawner
    GameObject heldItem = null;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //* Spawn a dagger when the game starts
        SpawnNewDagger();
    }

    private void Update()
    {
        bool isGameOver = ThrowKnifeGameManager.Instance.IsGameOver();
        if (Input.GetMouseButtonDown(0) && !isGameOver)
        {
            //? If the game is not over and mouse is clicked
            if (heldItem != null)
            {
                //? If a dagger is held by spawner
                //* Throw the dagger
                Dagger dagger = heldItem.GetComponent<Dagger>();
                dagger.Throw();
            }
        }
    }

    public void ClearChild()
    {
        //* Remove the held item
        heldItem = null;
    }

    public void SpawnNewDagger()
    {
        //* Spawn a new dagger at the spawner
        bool isGameOver = ThrowKnifeGameManager.Instance.IsGameOver();
        bool isGameWon = GameWonUI.Instance.isGameWon;
        if (heldItem == null && !isGameOver && !isGameWon)
        {
            heldItem = Instantiate(daggerPrefab, transform.position, daggerPrefab.transform.rotation);
            heldItem.transform.SetParent(transform);
        }
    }

}
