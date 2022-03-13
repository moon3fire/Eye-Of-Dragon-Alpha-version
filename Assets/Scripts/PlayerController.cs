using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    [SerializeField]
    private CharacterController playerController;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField]
    private Transform cameraTransform;

    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontalInput , 0 , verticalInput).normalized;

        if(direction.magnitude >= 0.1)
        {
            float targenAngle = Mathf.Atan2(direction.x , direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y , targenAngle , ref turnSmoothVelocity , turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f , angle , 0f);

            Vector3 moveDirection = Quaternion.Euler(0f , targenAngle , 0f) * Vector3.forward;
            playerController.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    
    }

    void Shoot()
    {
        Instantiate(bulletPrefab , transform.position , transform.rotation);
    }
}
