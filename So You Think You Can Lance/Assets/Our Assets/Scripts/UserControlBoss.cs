using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets._2D;
using UnitySampleAssets.CrossPlatformInput;

public class UserControlBoss : MonoBehaviour
{
  
    private PlatformerCharacter2D character;
    private bool jump;

    private void Awake()
    {
        character = GetComponent<PlatformerCharacter2D>();
    }

    private void Update()
    {
        if (!jump)
            // Read the jump input in Update so button presses aren't missed.
            jump = CrossPlatformInputManager.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        // Read the inputs.
        //bool crouch = Input.GetKey(KeyCode.LeftControl);
        //float h = CrossPlatformInputManager.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        jump = false;
    }
}
