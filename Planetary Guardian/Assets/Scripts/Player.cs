using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Collider2D collider;
    public Transform transform;
    public GameObject planet;
    private float radius = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = planet.transform.position.z - Camera.main.transform.position.z;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = mousePosition - planet.transform.position;
        direction = Vector3.ClampMagnitude(direction, radius);

        if ((double)direction.sqrMagnitude < (double)radius * (double)radius)
        {
            direction = direction.normalized * radius;
        }

        transform.position = planet.transform.position + direction;

    }
}
