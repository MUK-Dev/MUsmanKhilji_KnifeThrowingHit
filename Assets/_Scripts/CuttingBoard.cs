using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    //? Handles three types of boards
    private enum BoardType
    {
        Linear,
        Random,
        Reactive
    }

    [SerializeField] private BoardType boardType = BoardType.Linear;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private int boardHealth = 7;
    [SerializeField] private bool isClockwise = true;

    private int rotationAngle;
    private float changeAngleAfter = 0f;
    private float changeAngleAfterMax = 3f;
    private bool canRotate = true;

    private void Update()
    {
        bool isGameOver = ThrowKnifeGameManager.Instance.IsGameOver();
        if (canRotate && !isGameOver)
        {
            //? If board is allowed to rotate and game is not over
            switch (boardType)
            {
                default:
                case BoardType.Linear:
                    //? Linear just rotates continuously in one direction
                    rotationAngle = isClockwise ? 1 : -1;
                    transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * rotationAngle);
                    break;
                case BoardType.Random:
                    //? Random changes rotation after a random interval
                    changeAngleAfter += Time.deltaTime;
                    if (changeAngleAfter >= changeAngleAfterMax)
                    {
                        ToggleAngle();
                        changeAngleAfter = 0f;
                        changeAngleAfterMax = Random.Range(3f, 6f);
                    }
                    rotationAngle = isClockwise ? 1 : -1;
                    transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * rotationAngle);
                    break;
                case BoardType.Reactive:
                    //? Reactive changes rotation when mouse is clicked
                    if (Input.GetMouseButtonDown(0))
                    {
                        ToggleAngle();
                    }
                    rotationAngle = isClockwise ? 1 : -1;
                    transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * rotationAngle);
                    break;

            }
        }
    }

    private void ToggleAngle() => isClockwise = !isClockwise;

    public void DamageBoard()
    {
        //*  Reduce the life of board
        bool isGameOver = ThrowKnifeGameManager.Instance.IsGameOver();
        if (!isGameOver)
        {
            if (boardHealth - 1 <= 0)
            {
                boardHealth = 0;
                canRotate = false;
                EnableAllPhysics();
                GameWonUI.Instance.Show();
            }
            else
            {
                boardHealth--;
            }
        }
    }

    public void DisableAllPhysics()
    {
        //* Disable physics of all the child objects
        foreach (Transform child in transform)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }

    public void EnableAllPhysics()
    {
        //* Enable physics of all the child objects
        foreach (Transform child in transform)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }
}
