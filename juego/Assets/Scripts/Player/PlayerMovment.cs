using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovment : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField]
    private float moveSpeed = 10f;
    private readonly Matrix4x4 isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

    [Header("Input")]
    [SerializeField]
    private PlayerControls input;
    private Vector3 inputVector;

    [Header("Gravedad")]
    [SerializeField]
    private float groundedPullForce = 10f;

    private CharacterController characterController;

    void Awake()
    {
        input = new PlayerControls();
        characterController = GetComponent<CharacterController>();
    }

    void Move()
    {
        Vector3 rawInput = new Vector3(inputVector.x, 0f, inputVector.y);
        Vector3 moveDirection = Vector3.ClampMagnitude(isoMatrix.MultiplyPoint3x4(rawInput), 1f);

        // 3. Desplazamiento cinemático con CharacterController
        Vector3 motion = (moveDirection * moveSpeed) + (Vector3.up * groundedPullForce);
        characterController.Move(motion * Time.deltaTime);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
