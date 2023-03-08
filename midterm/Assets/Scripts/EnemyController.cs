using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float detectionRange;
    public bool activated;
    public float speed;
    public float activeTimer;
    public GameObject explode;

    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated) {
            transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
            activeTimer -= Time.deltaTime;
            if (activeTimer <= 0) {
                activated = false;
            }
        } else {
            if (Vector3.Distance(transform.position, player.position) < detectionRange) {
                activated = true;
                transform.LookAt(player);
                activeTimer = 4f;
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Ice")) {
            Destroy(gameObject);
        }
    }

    void OnDestroy() {
        GameObject e = Instantiate(explode, transform.position, Quaternion.identity, transform.parent);
        Destroy(e, 1f);
    }

    
}
