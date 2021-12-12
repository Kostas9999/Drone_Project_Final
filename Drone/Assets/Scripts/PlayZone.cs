using UnityEngine;

public class PlayZone : MonoBehaviour
{
    public float min_zone_Size = 30f;
    float deduct = 0.1f;
    int zone_Size = 1230;
    private SpawnManager spawnManager_Script;
    private GameMngr gameMngr_Script;


    // Start is called before the first frame update
    void Start()
    {

        min_zone_Size = 30f;
        transform.localScale = new Vector3(zone_Size, zone_Size, zone_Size);

        gameMngr_Script = GameObject.Find("GameMngr").GetComponent<GameMngr>();
        spawnManager_Script = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        InvokeRepeating("playZone_scaler_FN", 1, 0.01f); // invoke resize zone repeatedly 
    }

      void playZone_scaler_FN()
            {

                if (transform.localScale.x > min_zone_Size && GameMngr.alive) //resize zone
                {
                    transform.localScale = new Vector3(
                                                    transform.localScale.x - deduct,
                                                    transform.localScale.x - deduct,
                                                    transform.localScale.x - deduct
                                                     );
                }
                else { 
                    spawnManager_Script.CancelInvoke(); 
                    if(GameMngr.alive) {gameMngr_Script.survived = true;}
                    
                    }

            }
}
