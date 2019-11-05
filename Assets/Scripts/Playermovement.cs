using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    float speed = 4;
    float rotspeed = 80;
    float gravity = 8;
    float rot = 0f;

    Vector3 moveDir = Vector3.zero;

    TutorialText accessTutorialText;
    CharacterController controller;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        accessTutorialText = GameObject.Find("TutorialText").GetComponent<TutorialText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("Condition", 1);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);

                if (accessTutorialText.stageNum == 1f)
                { accessTutorialText.updateText(accessTutorialText.stageNum, 1f); }
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("Condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                if (accessTutorialText.stageNum == 1.2f)
                { accessTutorialText.updateText(accessTutorialText.stageNum, 1.2f); }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (accessTutorialText.stageNum == 1.4f)
                { accessTutorialText.updateText(accessTutorialText.stageNum, 1.4f); }
            }
        }
        rot += Input.GetAxis("Horizontal") * rotspeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }
}
