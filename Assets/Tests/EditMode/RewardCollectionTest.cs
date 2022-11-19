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

    [Test]
    public void CollectingRewardDeactivatesReward()
    {
        //ARRANGE
        GameObject gameObject = new GameObject("Coin", typeof(Coin));

        Coin coin = gameObject.GetComponent<Coin>() as Coin;
        gameObject.SetActive(true);

        //ACT
        coin.CoinCollected();

        //ASSERT
        Assert.IsFalse(gameObject.activeSelf);
    }

    [Test]
    public void ResetLevelActivatesAllCoins()
    {
        //ARRANGE
        GameObject coinObject1 = new GameObject("Coin1", typeof(Coin));
        GameObject coinObject2 = new GameObject("Coin2", typeof(Coin));
        GameObject playerObject = new GameObject("Player", typeof(Player));
        coinObject1.tag = "Coin";
        coinObject2.tag = "Coin";
        Player player = playerObject.GetComponent<Player>() as Player;
        Coin.InitCoins();
        coinObject1.SetActive(false);
        coinObject2.SetActive(false);

        //ACT
        player.resetLevel();

        //ASSERT
        Assert.IsTrue(coinObject1.activeSelf && coinObject2.activeSelf);
    }

}
