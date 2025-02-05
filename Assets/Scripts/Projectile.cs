using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int despawnTimer = 5;

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

    public void fireProjectile()
    {
        GameObject prefabInstance;
        prefabInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody rb = prefabInstance.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);

        Destroy(prefabInstance, 4);
    }
}
