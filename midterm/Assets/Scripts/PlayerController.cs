using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public float speed;
    public float turnSpeed;
    public GameManager gm;
    public int hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = 5;   
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        transform.Translate(transform.forward * vert * speed * Time.deltaTime, Space.World);
        transform.Rotate(new Vector3(0, turnSpeed * Time.deltaTime * horiz, 0));
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Pizza")) {
            Destroy(other.gameObject);
            gm.AddScore();
            hp = System.Math.Min(hp + 1, 5);
            gm.SetHealth(hp);
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag.Equals("Enemy")) {
            loseHp();
            Destroy(col.gameObject);
        }
    }

    public void loseHp() {
        hp -= 1;
        gm.SetHealth(hp);
    }
}
