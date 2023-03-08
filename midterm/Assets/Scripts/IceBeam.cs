using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBeam : MonoBehaviour
{
    public float countdown;
    public float growSpeed;

    // Start is called before the first frame update
    void Start()
    {
        countdown = 2;    
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        transform.localScale = transform.localScale + new Vector3(growSpeed * Time.deltaTime, growSpeed * Time.deltaTime, growSpeed * Time.deltaTime);
        if (countdown <= 0) {
            Destroy(gameObject);
        }
    }
}
