using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyTests
{
    [UnityTest]
    public IEnumerator EnemyCollisionDamagesPlayer()
    {

        //ARRANGE
        GameObject playerObject = new GameObject("playerObject", typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(Player), typeof(CharacterController));
        playerObject.tag = "Player";
        CharacterController controller = playerObject.GetComponent(typeof(CharacterController)) as CharacterController;
        GameObject enemyObject = new GameObject("enemyObject", typeof(BoxCollider2D), typeof(Enemy));
        Player player = playerObject.GetComponent(typeof(Player)) as Player;

        controller.player = player;
        player.controller = controller;
        controller.m_WhatIsGround = new LayerMask();
        controller.m_GroundCheck = playerObject.transform;
        float originalPosition = playerObject.transform.position.x;
        playerObject.transform.position = new Vector3(0f, 0.5f);
        player.health = 1;

        //ACT
        yield return new WaitForSeconds(.3f);

        //ASSERT
        Assert.AreEqual(0, player.health);
    }
}
