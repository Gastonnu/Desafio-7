using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{

    private float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RelocateWall()
    {
        float ejeX = Random.Range(5f, -5f);
        float ejeZ = Random.Range(5f, -5f);
        transform.position = new Vector3(ejeX, 2, ejeZ);
    }

    private void RotateWall()
    {
        float rotateY = Random.Range(0f, 180f);
        Quaternion angle = Quaternion.Euler(0, rotateY, 0);
        transform.localRotation = angle;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                timer = 2f;
                RelocateWall();
                RotateWall();
            }
        }
    }
}
