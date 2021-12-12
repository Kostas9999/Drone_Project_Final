using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Rigidbody drone_RB;
    public GameObject drone_OBJ;
    public Rigidbody Drone;

    private GameMngr gameMngr_Script;


    public GameObject playZone;


    public float speed = 4000f;

    public static bool isPaused;
    public GameObject inGameMenu;
    public GameObject in_Game_Menu_Button;



    float upForce, forwardForce, sideForce, turnSideSpeed;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        gameMngr_Script = GameObject.Find("GameMngr").GetComponent<GameMngr>();
        drone_RB = GetComponent<Rigidbody>();



        drone_OBJ = GameObject.Find("Drone_OBJ");

    }

    void Update()
    {
        if (GameMngr.alive)                                                     // run only if "alive"
        {
            checkedInput();
            know_Your_Limits();
            if (gameMngr_Script.survived)
                {transform.position = new Vector3(0, 0, 0);}
        }
        else
        {
            drone_OBJ.transform.Rotate(Vector3.back, 0.05f, Space.World);
            transform.position = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        drone_RB.AddRelativeForce(Vector3.up * upForce);
        drone_RB.AddRelativeForce(Vector3.forward * forwardForce);
        drone_RB.AddRelativeForce(Vector3.left * sideForce);
        drone_RB.AddRelativeTorque(transform.up * turnSideSpeed);

    }



    public void checkedInput()                                                  // user controls
    {
        if (gameMngr_Script.timeToPlay && !gameMngr_Script.survived)
        {

            // up / down
            if (Input.GetKey(KeyCode.UpArrow)) { upForce = speed; }
            else if (Input.GetKey(KeyCode.DownArrow)) { upForce = -3000; } 
            else { upForce = 98.1f; }

            // forward / backward
            if (Input.GetKey(KeyCode.W))
            { forwardForce = speed;}

            else if (Input.GetKey(KeyCode.S)) { forwardForce = -speed; }
            else { forwardForce = 98.1f; }

            //left / right
            if (Input.GetKey(KeyCode.A)) { sideForce = speed; }
            else if (Input.GetKey(KeyCode.D)) { sideForce = -speed; }
            else { sideForce = 98.1f; }

            if (Input.GetKey(KeyCode.RightArrow)) { turnSideSpeed = 200; }
            else if (Input.GetKey(KeyCode.LeftArrow)) { turnSideSpeed = -200; }
            else { turnSideSpeed = 0; }

            //left / right
            //       if (Input.GetKey(KeyCode.RightArrow))
            ///     { transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed / 2); }
            //     if (Input.GetKey(KeyCode.LeftArrow))
            //    { transform.Rotate(Vector3.up * Time.deltaTime * (-turnSpeed / 2)); }

        }

       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) { resume(); }
            else { pause(); }
        }

  

    }

    void know_Your_Limits()                                             // keep player in zone
    {
        float half_Of_playZone = playZone.transform.localScale.x / 2;
        if (drone_OBJ.CompareTag("Drone_OBJ"))
        {
            if (gameObject.transform.position.x > half_Of_playZone)
            {
                transform.position = new Vector3(transform.position.x - 10, transform.position.y, transform.position.z);
                gameMngr_Script.deduct_Health();
            }

            if (gameObject.transform.position.x < -half_Of_playZone)
            {
                transform.position = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
                gameMngr_Script.deduct_Health();
            }

            if (gameObject.transform.position.y > half_Of_playZone)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
                gameMngr_Script.deduct_Health();


            }
            if (gameObject.transform.position.y < -half_Of_playZone)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
                gameMngr_Script.deduct_Health();

            }

            if (gameObject.transform.position.z > half_Of_playZone)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);
                gameMngr_Script.deduct_Health();

            }
            if (gameObject.transform.position.z < -half_Of_playZone)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10);
                gameMngr_Script.deduct_Health();

            }

        }

    }
    // Pause/Resume
    public void resume()
    {
        inGameMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void pause()
    {
        inGameMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(in_Game_Menu_Button);
        Time.timeScale = 0;
        isPaused = true;
    }

    /// quit game


}
