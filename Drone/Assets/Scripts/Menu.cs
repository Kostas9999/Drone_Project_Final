using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject Cube_Description;
    public GameObject Drone_Model;
    public TextMeshProUGUI Cube_Top_Score;
    public GameObject FreeRun_Description;

    string scene = "Cube";

    public void start()
    {
        GameMngr.alive = true;
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }
                                                            // overloaded start function for in game menu (back to main)
    public static void start(string scene_temp) { Time.timeScale = 1f; SceneManager.LoadScene(scene_temp); }


                                                            // scene manage in main menu
    public void cube_Scene()
    {
        scene = "Cube";
        Drone_Model.gameObject.SetActive(false);
        FreeRun_Description.gameObject.SetActive(false);
        Cube_Description.gameObject.SetActive(true);

        Cube_Top_Score.text = "Top score is: " + GameMngr.TopScore;
    }


    public void race_Scene()
    {
        scene = "MainMenu";
        //  scene = "Race";                              // scene is under construction
         FreeRun_Description.gameObject.SetActive(false);
        Cube_Description.gameObject.SetActive(false);
        Drone_Model.gameObject.SetActive(true);
    }

    public void freeRun_Scene()
    {
        scene = "FreeRun";
        Drone_Model.gameObject.SetActive(false);
        Cube_Description.gameObject.SetActive(false);
        FreeRun_Description.gameObject.SetActive(true);
    }

                                                                                                        // Links
    public void link_GitHub() { Application.OpenURL("https://github.com/Kostas9999/IMM_Project_Alpha"); }
    public void link_WebGL() { Application.OpenURL("https://kostas9999.github.io/IMM_Project_Alpha/"); }





}




