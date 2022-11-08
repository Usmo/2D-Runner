using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerDeath
{
    // A Test behaves as an ordinary method
    [Test]
    public void PlayerDeathTest()
    {
        // ARRANGE
        GameObject gameobject = new GameObject("Object", typeof(Player));
        Player player = gameobject.GetComponent(typeof(Player)) as Player;

        GameObject deathScreenObject = new GameObject("DeathScreen", typeof(DeathScreen));
        DeathScreen screen = deathScreenObject.GetComponent(typeof(DeathScreen)) as DeathScreen;

        screen.panel = new GameObject("panel");
        player.deathScreen = screen;

        // ACT
        player.takeDamage();

        // ASSERT
        Assert.IsFalse(player.isAlive);
        
    }

    [Test]
    public void DeathScreenTest()
    {
        // ARRANGE
        GameObject gameobject = new GameObject("Object", typeof(Player));
        Player player = gameobject.GetComponent(typeof(Player)) as Player;

        GameObject deathScreenObject = new GameObject("DeathScreen", typeof(DeathScreen));
        DeathScreen screen = deathScreenObject.GetComponent(typeof(DeathScreen)) as DeathScreen;

        screen.panel = new GameObject("panel");
        player.deathScreen = screen;

        // ACT
        player.takeDamage();

        // ASSERT
        Assert.IsTrue(deathScreenObject.activeSelf);
        
    }

    [Test]
    public void ResetPlayerPosition()
    {
        // ARRANGE
        GameObject gameobject = new GameObject("Object", typeof(Player));
        Player player = gameobject.GetComponent(typeof(Player)) as Player;

        GameObject startingPosition = new GameObject("StartingPosition");

        GameObject deathScreenObject = new GameObject("Death Screen", typeof(DeathScreen));
        DeathScreen screen = deathScreenObject.GetComponent(typeof(DeathScreen)) as DeathScreen;

        screen.panel = new GameObject("panel");
        player.deathScreen = screen;
        player.startPosition = new GameObject("Start");

        player.transform.position = new Vector3(2, 3, 0);

        player.isAlive = false;
        player.health = 0;

        screen.player = player;

        // ACT
        screen.resetLevel();

        // ASSERT
        Assert.AreEqual(player.transform.position, startingPosition.transform.position);

    }

    [Test]
    public void ResetPlayerHPandIsAlive()
    {
        // ARRANGE
        GameObject gameobject = new GameObject("Object", typeof(Player));
        Player player = gameobject.GetComponent(typeof(Player)) as Player;

        GameObject deathScreenObject = new GameObject("Death Screen", typeof(DeathScreen));
        DeathScreen screen = deathScreenObject.GetComponent(typeof(DeathScreen)) as DeathScreen;

        screen.panel = new GameObject("panel");
        player.deathScreen = screen;

        player.isAlive = false;
        player.health = 0;
        player.startPosition = new GameObject("Start");

        screen.player = player;

        // ACT
        screen.resetLevel();

        // ASSERT
        Assert.IsTrue(player.isAlive);
        Assert.AreEqual(player.health, 1);

    }

}