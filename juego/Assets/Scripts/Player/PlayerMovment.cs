using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovment : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField]
    private float moveSpeed = 10f;
    private readonly Matrix4x4 isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, -45, 0));

    [Header("Input")]
    [SerializeField]
    private InputReader input;
    private Vector3 inputVector;

    [Header("Gravedad")]
    [SerializeField]
    private float groundedPullForce = -9.8f;

    private CharacterController characterController;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void HandleInput(Vector2 input)
    {
        inputVector = input;
    }

    void Move()
    {
        Vector3 rawInput = new Vector3(inputVector.x, 0f, inputVector.y);
        Vector3 moveDirection = Vector3.ClampMagnitude(isoMatrix.MultiplyPoint3x4(rawInput), 1f);

        Vector3 motion = (moveDirection * moveSpeed) + (Vector3.up * groundedPullForce);
        characterController.Move(motion * Time.deltaTime);
    }

    void OnEnable()
    {
        input.MoveEvent += HandleInput;
    }

    void OnDisable()
    {
        input.MoveEvent -= HandleInput;
    }
}
