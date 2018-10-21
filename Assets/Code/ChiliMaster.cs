using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChiliMaster : MonoBehaviour {

    private List<Transform> ChiliGrass = new List<Transform>();
    [SerializeField] private Text PlayerFeedback;

	void Start () {
        ChiliGrass.Clear();
        foreach (Transform Child in transform) ChiliGrass.Add(Child);
	}
	
    public void ChiliDied(int Index)
    {
        ChiliGrass[Index].gameObject.SetActive(false);
        int StillActive = 0;
        foreach (Transform Chili in ChiliGrass) if (Chili.gameObject.activeSelf) StillActive++;
        PlayerFeedback.text = "Only " + StillActive + " chillipowder plants left!";
        Invoke("ClearText", 2);
        if (StillActive == 0)
        {
            PlayerFeedback.text = "YOU LOST! Try again and git gud";
            //Invoke("SwitchToMainMenu", 5);
        }
    }

    private void SwitchToMainMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
        SceneManager.UnloadSceneAsync("Level 0");
    }

    private void ClearText()
    {
        PlayerFeedback.text = "";
    }
	
}
