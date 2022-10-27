using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GoalEditTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void playerReachingGoalActivatesWinScreen()
    {
        //ARRANGE
        GameObject canvasObject = new GameObject("WinScreen");
        GameObject playerObject = new GameObject("PlayerObject", typeof(Player));

        GameObject goalObject = new GameObject("GoalObject", typeof(GoalScript));

        GoalScript goalscript = goalObject.GetComponent<GoalScript>();
        goalscript.WinScreen = canvasObject;

        //ACT
        goalscript.playerReachesGoal();

        //ASSERT
        Assert.True(canvasObject.activeSelf);
        Time.timeScale = 1f; //Set timescale back to 1 because playerReachesGoal() function sets TimeScale to 0 in the project settings.
    }

    [Test]
    public void playerReachingGoalPausesGame()
    {
        //ARRANGE
        GameObject canvasObject = new GameObject("WinScreen");
        GameObject playerObject = new GameObject("PlayerObject", typeof(Player));

        GameObject goalObject = new GameObject("GoalObject", typeof(GoalScript));

        GoalScript goalscript = goalObject.GetComponent<GoalScript>();
        goalscript.WinScreen = canvasObject;

        //ACT
        goalscript.playerReachesGoal();

        //ASSERT
        Assert.AreEqual(0f, Time.timeScale);
        Time.timeScale = 1f; //Set timescale back to 1 because playerReachesGoal() function sets TimeScale to 0 in the project settings.
    }

}
