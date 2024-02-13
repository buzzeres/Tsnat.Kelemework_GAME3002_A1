using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float turnSpeed = 1.0f;
    private Rigidbody rigidBodyComponent;
    [SerializeField] private GameObject ballTemplate;
    [SerializeField] private Transform shootingPoint;
    private float shootPower = 0.0f;
    private float verticalShootPower = 0.0f;
    [SerializeField] private float maxShootPower = 30.0f;

    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessMovement();
        ProcessRotation();
        ProcessShooting();
    }

    private void ProcessMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); 
        float verticalInput = Input.GetAxisRaw("Vertical"); 

       
        Vector3 movementDirection = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;

        
        rigidBodyComponent.velocity = transform.TransformDirection(movementDirection) * moveSpeed + new Vector3(0, rigidBodyComponent.velocity.y, 0);
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.up * turnSpeed);
        }
        else if (Input.GetKey(KeyCode.F))
        {
            transform.Rotate(Vector3.down * turnSpeed);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position -= Vector3.forward * moveSpeed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.back * moveSpeed * Time.deltaTime;
        }


    }


    private void ProcessShooting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space key is being pressed.");
            shootPower = Mathf.Min(shootPower + Time.deltaTime * 10, maxShootPower);
            verticalShootPower += Time.deltaTime * 5;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space key was released.");
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject ballInstance = Instantiate(ballTemplate, shootingPoint.position, Quaternion.identity);
        Vector3 forwardForce = transform.forward * shootPower;
        Vector3 upwardForce = Vector3.up * verticalShootPower;
        Vector3 combinedForce = forwardForce + upwardForce;

        ballInstance.GetComponent<Rigidbody>().AddForce(combinedForce, ForceMode.Impulse);
        Debug.Log($"Applied Force: {combinedForce.magnitude}");
        ResetShootPower();
    }

    private void ResetShootPower()
    {
        shootPower = 0.0f;
        verticalShootPower = 0.0f;
    }

    public float GetForwardPower() => shootPower;
    public float GetUpwardPower() => verticalShootPower;
}
