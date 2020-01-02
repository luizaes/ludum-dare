using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public Transform transform;
    public Collider2D collider;
    private GameObject planet;
    private int side;

    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.Find("Planet");

        side = (int) Random.Range(0, 4);

        if(side == 1)
        {
            Vector3 position = new Vector3(Random.Range(-14f, 14f), 8f, 0f);
            transform.position = position;
        } else if(side == 2)
        {
            Vector3 position = new Vector3(15f, Random.Range(-6f, 6f), 0f);
            transform.position = position;
        } else if(side == 3)
        {
            Vector3 position = new Vector3(Random.Range(-14f, 14f), -8f, 0f);
            transform.position = position;
        } else
        {
            Vector3 position = new Vector3(-15f, Random.Range(-6f, 6f), 0f);
            transform.position = position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
