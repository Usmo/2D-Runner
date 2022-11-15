using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ScoreTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void DeductScoreLowersScoreByOne()
    {
        // ARRANGE
        GameObject scoreObject = new GameObject("Object", typeof(ScoreController));
        ScoreController scoreController = scoreObject.GetComponent(typeof(ScoreController)) as ScoreController;
        scoreController.timeLeft = 0.0f;
        scoreController.timeScore = 1000;

        // ACT
        scoreController.deductScore();

        // ASSERT
        Assert.AreEqual(999, scoreController.timeScore);
    }
    
    [Test]
    public void AddingScoreTest()
    {
        // ARRANGE
        GameObject gameobject = new GameObject("Object", typeof(ScoreController));
        ScoreController controller = gameobject.GetComponent(typeof(ScoreController)) as ScoreController;
        controller.score = 0;

        // ACT
        controller.addScore(5);

        // ASSERT
        Assert.AreEqual(controller.score, 5);

    }

    [Test]
    public void ResetScoreOnResetLevel()
    {
        // ARRANGE
        GameObject gameobject = new GameObject("Object", typeof(Player));
        Player player = gameobject.GetComponent(typeof(Player)) as Player;

        GameObject scoreControllerObject = new GameObject("ScoreObject", typeof(ScoreController));
        ScoreController scoreController = scoreControllerObject.GetComponent(typeof(ScoreController)) as ScoreController;

        player.scoreController = scoreController;
        scoreController.score = 500;
        scoreController.timeScore = 900;

        // ACT
        player.resetLevel();

        // ASSERT
        Assert.AreEqual(scoreController.score, 0);

    }
}
