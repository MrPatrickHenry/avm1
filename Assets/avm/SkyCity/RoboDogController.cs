using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RoboDogController : MonoBehaviour
{
    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;
    public float moveSpeed = 5.0f;
    private Vector2 moveDirection = Vector2.zero;

    private void Start()
    {
        upButton.onClick.AddListener(MoveUp);
        downButton.onClick.AddListener(MoveDown);
        leftButton.onClick.AddListener(MoveLeft);
        rightButton.onClick.AddListener(MoveRight);
    }

    private void Update()
    {
        MoveRoboDog();
    }

    private void MoveRoboDog()
    {
        transform.position += (Vector3)moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveUp()
    {
        moveDirection = Vector2.up;
    }

    public void MoveDown()
    {
        moveDirection = Vector2.down;
    }

    public void MoveLeft()
    {
        moveDirection = Vector2.left;
    }

    public void MoveRight()
    {
        moveDirection = Vector2.right;
    }
}
