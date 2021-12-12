using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    bool isColliding;
    public GameMngr GameMngr_Script;
    float half_Of_playZone;
    public GameObject playZone;
    public Sound Sound_Script;


    
public Sound sound_obj;
  

    // Start is called before the first frame update
    void Start()
    {
        playZone = GameObject.Find("PlayZone");
        Sound_Script = GameObject.Find("Sound").GetComponent<Sound>();
        GameMngr_Script = GameObject.Find("GameMngr").GetComponent<GameMngr>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isColliding = false;
        half_Of_playZone = playZone.transform.localScale.x / 2;   // get half of playzone (on x axis)
        destroy_FN();
    }

    private void OnTriggerEnter(Collider other)
    {
        //-----------------------------------------------------------------------------------------------
        if (isColliding) return;
        isColliding = true;
        //https://answers.unity.com/questions/738991/ontriggerenter-being-called-multiple-times-in-succ.html
        
        Sound_Script.hit_Zone();
       if (!gameObject.CompareTag("PowerUp_Flame")){Destroy(gameObject);};                // destry item when collected

        if (gameObject.CompareTag("Point_Item"))                        // adding value of item (*subject to change)
        { GameMngr_Script.score += 5; }

        if (gameObject.CompareTag("Time_Item"))
        { GameMngr_Script.score += 10; }

        if (gameObject.CompareTag("Speed_Item"))
        { GameMngr_Script.score += 15; }

       if (gameObject.CompareTag("PowerUp_Item_Flame"))
        {GameMngr_Script.powerUp_Flame();}   
    }

    void destroy_FN()
    {
        // remove out of screen items (collectable items only)
        if (gameObject.CompareTag("Point_Item") || gameObject.CompareTag("Time_Item") || gameObject.CompareTag("Speed_Item") || gameObject.CompareTag("PowerUp_Item_Flame"))
        {
            if (gameObject.transform.position.x > half_Of_playZone) { Destroy(gameObject); }
            if (gameObject.transform.position.x < -half_Of_playZone) { Destroy(gameObject); }

            if (gameObject.transform.position.y > half_Of_playZone) { Destroy(gameObject); }
            if (gameObject.transform.position.y < -half_Of_playZone) { Destroy(gameObject); }

            if (gameObject.transform.position.z > half_Of_playZone) { Destroy(gameObject); }
            if (gameObject.transform.position.z < -half_Of_playZone) { Destroy(gameObject); }
        }

    }


}
