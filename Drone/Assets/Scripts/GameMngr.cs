using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;


public class GameMngr : MonoBehaviour
{

    public ParticleSystem playZoneTouch;
    public GameObject game_Over;
    public static GameObject playZone;
    public static bool alive;
    public int score, time, health;
    public static int TopScore = 299;
    public bool timeToPlay = false;

 

    private AudioSource audioSource;
    public AudioClip hit_Zone_Electric;

    public bool survived = false;

    float current_Time;
    float countDown_Time = 4;
    public TextMeshProUGUI countDown_Text;

public GameObject powerUp;

    // Start is called before the first frame update
    void Start()
    {
        playZone = GameObject.Find("PlayZone");
        // initial settings
        current_Time = (int)countDown_Time;
        alive = true;
        score = 0;
        time = 0;
        health = 100;

        audioSource = GetComponent<AudioSource>();

            

    }

    // Update is called once per frame
    void Update()
    {
        if (alive && timeToPlay) { time = (((int)playZone.transform.localScale.x / 10) - 3); } // calculate time to end of zone shrink
        if (survived) { game_Over.gameObject.SetActive(true); }                                   //end of game screen when survived 

        isTimeTo_Play();
    }

    public void deduct_Health()                                     // do damage when hitint zone border
    {
        powerUp.gameObject.SetActive(false);                        //remove powerUp on zone wall touch
         
        if (!SceneManager.GetActiveScene().name.Equals("FreeRun")) // no damage in practice mode
        {
            if (health > 5)
            {
             if(alive && !survived)  { health -= 5;}
                playZoneTouch.Play();
                audioSource.PlayOneShot(hit_Zone_Electric, 1.0f);
            }
            else
            {
                health = 0;
                gameOver();
                alive = false; 
            }
        }
    }

    // scene manage functions
    public void gameOver() { game_Over.gameObject.SetActive(true); }
    public void MainMenu_Scene() { SceneManager.LoadScene(0); }
    public void cube_Scene() { SceneManager.LoadScene(1); }
    public void freeRun_Scene() { SceneManager.LoadScene(2); }
    public void restart_Game() { Time.timeScale = 1; SceneManager.LoadScene(SceneManager.GetActiveScene().name); }


    public void isTimeTo_Play()
    {                                                                   // time countdown
        if (current_Time < -1) { countDown_Text.text = ""; }          // destry obj instead
        if (current_Time < 1 && current_Time > -3) { countDown_Text.text = "GO!!!"; }
        if (current_Time < 4 && current_Time > 0) { countDown_Text.text = current_Time.ToString("0"); }
        if (current_Time > 3) { countDown_Text.text = "Ready?!"; }

        current_Time -= 1 * Time.deltaTime;
        timeToPlay = current_Time < 0 ? true : false;
        // TODO poorly written countDown code, must be replaced
    }

   public void powerUp_Flame()
   {
       powerUp.gameObject.SetActive(true);
       StartCoroutine(powerUp_Flame_CountDown());
       }

       IEnumerator powerUp_Flame_CountDown()
       {
           yield return new WaitForSeconds(10);

            powerUp.gameObject.SetActive(false);

       }
   

}
