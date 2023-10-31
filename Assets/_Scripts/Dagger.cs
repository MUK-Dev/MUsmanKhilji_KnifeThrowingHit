using UnityEngine;

public class Dagger : MonoBehaviour
{
    private const string CUTTING_BOARD = "CuttingBoard";
    private const string DAGGER = "Dagger";
    [SerializeField] private float speed = 20f;
    [SerializeField] private ParticleSystem woodDustParticles;
    [SerializeField] private AudioClip woodSound;
    [SerializeField] private AudioClip metalSound;

    private bool canMove = false;
    private Rigidbody rb;
    private new AudioSource audio;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        woodDustParticles.Stop();
    }

    private void Update()
    {
        bool isGameOver = ThrowKnifeGameManager.Instance.IsGameOver();
        bool isGameWon = GameWonUI.Instance.isGameWon;
        if (canMove && !isGameOver && !isGameWon)
        {
            //? Start moving the dagger if dagger is allowed to move and the game is playing
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }

    public void Throw() => canMove = true;
    public void StopMoving() => canMove = false;

    private void OnCollisionEnter(UnityEngine.Collision other)
    {
        //* When dagger hits another dagger
        if (other.gameObject.CompareTag(DAGGER) && !transform.parent.CompareTag(CUTTING_BOARD) && !GameWonUI.Instance.isGameWon)
        {
            StopMoving();
            rb.freezeRotation = false;
            rb.useGravity = true;
            audio.PlayOneShot(metalSound, 1);
            GameOverUI.Instance.Show();
            ThrowKnifeGameManager.Instance.FinishGame();
        }
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        //* When dagger hits the cutting board
        bool isGameOver = ThrowKnifeGameManager.Instance.IsGameOver();
        if (other.gameObject.CompareTag(CUTTING_BOARD) && !isGameOver && !GameWonUI.Instance.isGameWon)
        {
            CuttingBoard cuttingBoard = other.gameObject.GetComponent<CuttingBoard>();
            cuttingBoard.DamageBoard();
            woodDustParticles.Play();
            audio.PlayOneShot(woodSound, 1);
            transform.SetParent(other.transform);
            StopMoving();
            DaggerSpawner.Instance.ClearChild();
            DaggerSpawner.Instance.SpawnNewDagger();
        }
    }
}
