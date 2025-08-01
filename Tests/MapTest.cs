using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class MapTest : InputTestFixture
{
    public override void Setup()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Map");
        base.Setup();
    }
    [UnityTest]
    public IEnumerator TestMapItem()
    {
        GameObject mapItem = GameObject.Find("MapItem - The Alamo");
        
        Assert.IsNotNull(mapItem, "Map item should be present in the scene.");
        

        mapItem.GetComponent<MapItem>().DisplayInfo();
        yield return new WaitForFixedUpdate();
        
        Assert.IsTrue(UIManager.GetInstance().mutex, "Mutex should be true");
        GameObject displayPanel = GameObject.Find("Body");
        Assert.IsNotNull(displayPanel, "Display panel should be present in the scene.");
        string description = mapItem.GetComponent<MapItem>().description;
        Assert.IsTrue(displayPanel.GetComponent<TextMeshProUGUI>().text.Equals(description));
    }

    
}
