using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        if (!anim)
            anim = GetComponent<Animator>();
        isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("runSpeed", Input.GetAxis("Vertical"));
        if (Input.GetButtonDown("Fire1"))
            anim.SetTrigger("slash");

        if (Input.GetKeyDown(KeyCode.LeftShift))
            isRunning = true;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            isRunning = false;

        if (isRunning == false)
            anim.SetBool("isRunning", false);

        if (isRunning == true)
        {
            anim.SetBool("isRunning", true);
            anim.SetFloat("runSpeed", Input.GetAxis("Vertical") / 2f);
        }
    }
}
