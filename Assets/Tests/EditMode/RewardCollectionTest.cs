using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RewardCollectionTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void CollectingRewardIncreasesScore()
    {
        // Use the Assert class to test conditions

        //ARRANGE
        GameObject gameObject = new GameObject("ScroreController", typeof(ScoreController));

        ScoreController scoreController = gameObject.GetComponent<ScoreController>();

        scoreController.score = 0f;

        //ACT
        scoreController.addRewardScore();

        //ASSERT
        Assert.AreEqual(scoreController.rewardValue, scoreController.score);

    }
}
