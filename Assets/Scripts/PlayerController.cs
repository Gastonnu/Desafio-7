using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 4f;
    private bool isBig = true;
    private float cooldown = 1.5f;
    private float cameraEjeX;

    private Rigidbody rbPlayer;


    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Move();
        RotatePlayer();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        transform.Translate(speed * Time.deltaTime  * direction);
    }

    private void RotatePlayer()
    {
        cameraEjeX += Input.GetAxis("Mouse X");
        Quaternion angle = Quaternion.Euler(0, cameraEjeX, 0);
        transform.localRotation = angle;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            if (isBig && (cooldown < 0f))
            {
                cooldown = 1.5f;
                transform.localScale /= 2;
                isBig = false;
            }
            if(!isBig && (cooldown < 0f))
            {
                cooldown = 1.5f;
                transform.localScale *= 2;
                isBig = true;
            }
        }
    }



}
