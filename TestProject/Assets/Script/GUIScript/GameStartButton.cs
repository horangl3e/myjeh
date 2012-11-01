using UnityEngine;
using System.Collections;

public class GameStartButton : MonoBehaviour {
    void OnClick()
    {
        Debug.Log("GameStartButton Click");
		Application.LoadLevel("Level1");
    }
}
