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
        GameObject player = new GameObject("Player", typeof(Rigidbody2D), typeof(CharacterController), typeof(Player));
        CharacterController controller = player.GetComponent(typeof(CharacterController)) as CharacterController;
        Player playerscript = player.GetComponent(typeof(Player)) as Player;
        controller.player = playerscript;
        playerscript.controller = controller;
        controller.m_WhatIsGround = new LayerMask();
        controller.m_GroundCheck = player.transform;
        float originalPosition = player.transform.position.x;

        // ACT 
        controller.Move(1 * Time.fixedDeltaTime, false);
        // Use yield to skip a frame.
        yield return new WaitForSeconds(.1f);

        // ASSERT
        Assert.Greater(player.transform.position.x, originalPosition);

    }
    
    [UnityTest]
    public IEnumerator negative_movement_moves_left()
    {
        // ARRANGE
        GameObject player = new GameObject("Player", typeof(Rigidbody2D), typeof(CharacterController), typeof(Player));
        CharacterController controller = player.GetComponent(typeof(CharacterController)) as CharacterController;
        Player playerscript = player.GetComponent(typeof(Player)) as Player;
        controller.player = playerscript;
        playerscript.controller = controller;
        controller.m_WhatIsGround = new LayerMask();
        controller.m_GroundCheck = player.transform;
        float originalPosition = player.transform.position.x;

        // ACT 
        controller.Move(-1 * Time.fixedDeltaTime, false);
        // Use yield to skip a frame.
        yield return new WaitForSeconds(.1f);

        // ASSERT
        Assert.Less(player.transform.position.x, originalPosition);
    } 
}