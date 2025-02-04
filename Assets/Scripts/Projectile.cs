using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 10.0f;
    [SerializeField] private GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject prefabInstance;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            prefabInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody rb = prefabInstance.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        }

/*        transform.Rotate(Vector3.forward * speed * Time.deltaTime);*/
        
    }
}
