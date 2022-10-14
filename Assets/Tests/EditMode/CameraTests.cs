using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void CameraFollowsPlayerPosition()
    {
        // ARRANGE
        GameObject cameraObject = new GameObject("Camera", typeof(CameraController));
        CameraController cameraController = cameraObject.GetComponent(typeof(CameraController)) as CameraController;
        GameObject playerObject = new GameObject("Player");
        cameraController.target = playerObject;
        // We can assume both objects spawn at 0,0,0 position

        // ACT
        playerObject.transform.position = new Vector3(100, 20);
        cameraController.updateCameraPosition();

        // ASSERT
        Vector3 cameraVector = new Vector3(cameraObject.transform.position.x, cameraObject.transform.position.y);
        // Added yOffset to player y position so they should have same position
        Vector3 playerVector = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y + cameraController.yOffset);

        Assert.AreEqual(cameraVector, playerVector);
    }

    [Test]
    public void Cameras_Y_PositionDontGoBelow_Y_minimumValue()
    {
        // ARRANGE
        GameObject cameraObject = new GameObject("Camera", typeof(CameraController));
        CameraController cameraController = cameraObject.GetComponent(typeof(CameraController)) as CameraController;
        GameObject playerObject = new GameObject("Player");
        cameraController.target = playerObject;
        // We can assume both objects spawn at 0,0,0 position

        // ACT
        playerObject.transform.position = new Vector3(20, -50);
        cameraController.updateCameraPosition();

        // ASSERT
        Assert.AreEqual(cameraController.y_minimumValue, cameraObject.transform.position.y - cameraController.yOffset);
    }
}
