using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor;

public class MenuController : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject MLPanel;
    public GameObject CompPanel;
    public GameObject PalPanel;
    public GameObject ParenPanel;
    public GameObject PalLang;
    public GameObject ParLang;
    public GameObject Learning;

    void Start()
    {

       
            MLPanel.SetActive(false);
            CompPanel.SetActive(false);
            PalPanel.SetActive(false);
            ParenPanel.SetActive(false);
            MainPanel.SetActive(true);
            PalLang.SetActive(false);
            ParLang.SetActive(false);
             Learning.SetActive(false);


    }

    public void GotoPenguinScene()
    {
        SceneManager.LoadScene("Penguins");
    }

    public void GotoHummingBirdScene()
    {
        SceneManager.LoadScene("FlowerIsland");
    }

    public void Goto5AScene()
    {
        SceneManager.LoadScene("5AScene");
    }

    public void Goto5BScene()
    {
        SceneManager.LoadScene("5BScene");
    }

    public void GotoInstructorLink()
    {
        Application.OpenURL("http://www.niazilab.com");
    }

    public void Quit()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void PalLanguage()
    {
        PalLang.SetActive(true);
   
    }

    public void ParLanguage()
   {
        ParLang.SetActive(true);
    }
    public void CourseLearning()
    {
        Learning.SetActive(true);

    }


    public void GotoMLPanel()
    {
        MainPanel.SetActive(false);

        CompPanel.SetActive(false);
        PalPanel.SetActive(false);
        ParenPanel.SetActive(false);
        MLPanel.SetActive(true);
        PalLang.SetActive(false);
        ParLang.SetActive(false);
        Learning.SetActive(false);


    }

    public void GotoCompPanel()
    {
        MLPanel.SetActive(false);
        PalPanel.SetActive(false);
        ParenPanel.SetActive(false);
        MainPanel.SetActive(false);
        CompPanel.SetActive(true);
        PalLang.SetActive(false);
        ParLang.SetActive(false);
        Learning.SetActive(false);

    }

    public void GotoPalPanel()
    {
        MLPanel.SetActive(false);
        CompPanel.SetActive(false);
        ParenPanel.SetActive(false);
        MainPanel.SetActive(false);
        PalPanel.SetActive(true);
        ParLang.SetActive(false);
        PalLang.SetActive(false);

        PalLang.SetActive(false);
        ParLang.SetActive(false);
        Learning.SetActive(false);

    }

    public void GotoParenPanel()
    {
        MLPanel.SetActive(false);
        CompPanel.SetActive(false);
        PalPanel.SetActive(false);
        MainPanel.SetActive(false);
        ParenPanel.SetActive(true);
        ParLang.SetActive(false);
        PalLang.SetActive(false);
        PalLang.SetActive(false);
        ParLang.SetActive(false);
        Learning.SetActive(false);

    }

    public void GotoMainPanel()
    {
        MLPanel.SetActive(false);
        CompPanel.SetActive(false);
        PalPanel.SetActive(false);
        ParenPanel.SetActive(false);
        MainPanel.SetActive(true);
        PalLang.SetActive(false);
        ParLang.SetActive(false);
        Learning.SetActive(false);
    }
}
