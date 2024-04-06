using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public Transform axe;
    public Transform start;
    public Transform end;
    bool swung;

    RaycastHit hit;
    public AudioSource axeSound;
    public AudioSource goblinSound;

    // Start is called before the first frame update
    void Start()
    {
        swung = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused && Input.GetKeyDown(KeyCode.Mouse0)) {
            swung = true;
            axeSound.Play(0);
        }

        if (swung) {
            axe.transform.localPosition = Vector3.Slerp(axe.localPosition, end.transform.localPosition, 0.01f);
            axe.transform.localRotation = Quaternion.Slerp(axe.localRotation, end.transform.localRotation, 0.01f);

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1)) {
                if (hit.collider.tag == "enemy") {
                    goblinSound.Play(0);
                    Destroy(hit.collider.gameObject);
                    GameController.points += 1;
                }
            }

            float dist = Vector3.Distance(axe.transform.localPosition, end.transform.localPosition);
            if (dist <= 0.1f) {
                swung = false;
                axe.transform.localPosition = start.transform.localPosition;
                axe.transform.localRotation = start.transform.localRotation;
            }
        }

    }
}
