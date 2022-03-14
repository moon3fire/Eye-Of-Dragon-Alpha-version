using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    private float flySpeed = 25.0f;
    public GameObject PlayerObj;
    private Rigidbody bulletRb;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = PlayerObj.transform.rotation.y;
        Vector3 moveDirection = Quaternion.Euler(0 , angle , 0) * Vector3.forward;
        bulletRb.AddForce(moveDirection * flySpeed * Time.deltaTime , ForceMode.Impulse);
    }
}
