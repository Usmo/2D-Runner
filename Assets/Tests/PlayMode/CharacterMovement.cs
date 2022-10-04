using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CharacterMovement
{
    [UnityTest]
    public IEnumerator positive_movement_moves_right()
    {
        // ARRANGE
        GameObject player = new GameObject("Player");
        Rigidbody2D mRigidbody = player.AddComponent<Rigidbody2D>();
        CharacterController controller = player.AddComponent<CharacterController>();
        controller.m_WhatIsGround = new LayerMask();
        controller.m_GroundCheck = player.transform;
        float runspeed = 40f;
        float originalPosition = player.transform.position.x;

        // ACT 
        controller.Move(1 * runspeed * Time.fixedDeltaTime, false);

        // Use yield to skip a frame.
        yield return new WaitForSeconds(.3f);

        // ASSERT
        Assert.Greater(player.transform.position.x, originalPosition);

    }

    [UnityTest]
    public IEnumerator negative_movement_moves_left()
    {
        // ARRANGE
        GameObject player = new GameObject("Player");
        Rigidbody2D mRigidbody = player.AddComponent<Rigidbody2D>();
        CharacterController controller = player.AddComponent<CharacterController>();
        controller.m_WhatIsGround = new LayerMask();
        controller.m_GroundCheck = player.transform;
        float runspeed = 40f;
        float originalPosition = player.transform.position.x;

        // ACT 
        controller.Move(-1 * runspeed * Time.fixedDeltaTime, false);

        // Use yield to skip a frame.
        yield return new WaitForSeconds(.3f);

        // ASSERT
        Assert.Less(player.transform.position.x, originalPosition);
    }
}
