using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Larpas : MonoBehaviour
{
    public bool activated;
    public GameObject ice;
    public Transform gun;
    public float offScreenX;
    public float onScreenX;
    public float countdown;
    public float larpasSpeed;
    public bool iced;
    public GameObject iceParticle;

    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        iced = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !activated) {
            activated = true;
            countdown = 0;
            iced = false;
        }

        if (activated) {
            countdown += Time.deltaTime;
            float currentX = System.Math.Min(offScreenX + countdown * larpasSpeed, onScreenX);
            if (countdown > 3 && !iced) {
                iced = true;
                GameObject.Instantiate(ice, transform.position + transform.forward * 10, Quaternion.identity);
                iceParticle.SetActive(true);
            }
            if (countdown > 4) {
                currentX = System.Math.Max(onScreenX - (countdown - 4) * larpasSpeed, offScreenX);
                iceParticle.SetActive(false);
            }
            transform.localPosition = new Vector3(currentX, transform.localPosition.y, transform.localPosition.z);
            if (countdown > 7) {
                activated = false;
            }
        }
    }
}
