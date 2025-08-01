using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;

public class TestScript : InputTestFixture
{
    Keyboard keyboard;
    GameObject player = Resources.Load<GameObject>("Player");
    GameObject interactable = Resources.Load<GameObject>("Interactable");
    public override void Setup()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/TestingScene");
        base.Setup();
        keyboard = InputSystem.AddDevice<Keyboard>();

        var mouse = InputSystem.AddDevice<Mouse>();
        Press(mouse.rightButton);
        Release(mouse.rightButton); ;
    }

    [Test]
    public void TestPlayerInstantiation()
    {
        GameObject characterInstance = GameObject.Instantiate(player, Vector3.zero, Quaternion.identity);
        Assert.That(characterInstance, !Is.Null);
    }
    [UnityTest]
    public IEnumerator TestPlayerMoves()
    {
        GameObject characterInstance = GameObject.Instantiate(player, Vector3.zero, Quaternion.identity);
        Assert.That(characterInstance, !Is.Null);
        var playerController = characterInstance.GetComponent<PlayerController>();
        Assert.That(playerController, !Is.Null);
        Vector3 initialPosition = characterInstance.transform.position;
        // Simulate movement input
        Press(keyboard.wKey);
        yield return new WaitForSeconds(0.2f); // Wait for one frame to allow the movement to process
        Release(keyboard.wKey);
        // Check if the player has moved
        Assert.That(characterInstance.transform.position, Is.Not.EqualTo(initialPosition));
    }
    [UnityTest]
    public IEnumerator TestPlayerCanInteract()
    {
        var playerObj = GameObject.Instantiate(player, Vector3.zero, Quaternion.identity);
        var controller = playerObj.GetComponent<PlayerController>();

        var interactableObj = GameObject.Instantiate(
            interactable,
            playerObj.transform.position + playerObj.transform.forward * 2 + Vector3.down,
            Quaternion.identity
        );

        yield return new WaitForFixedUpdate();
        yield return null;

        RaycastHit hit;
        bool didHit = Physics.Raycast(playerObj.transform.position, playerObj.transform.forward, out hit, 5f);

        Debug.Log("Raycast hit: " + hit.collider?.name);
        Assert.IsTrue(didHit, "Raycast did not hit any object.");

        controller.Interact(hit);
        Assert.IsTrue(UIManager.GetInstance().mutex, "UIManager mutex should be true after interaction.");
    }
}
