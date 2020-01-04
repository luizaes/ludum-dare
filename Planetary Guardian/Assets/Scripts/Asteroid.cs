using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public Transform trans;
    private GameObject planet;

    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.Find("Planet");
        trans = gameObject.GetComponent<Transform>();
        //transform = GameObject.Find("Asteroid").transform;
    }

    // Update is called once per frame
    void Update()
    {
        trans.position = trans.position - (trans.position - planet.transform.position) / 1000;
    }
}
