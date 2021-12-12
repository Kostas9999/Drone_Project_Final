using UnityEngine;

public class Propellers : MonoBehaviour
{

// script for propellers to spin, TODO: remove script on new drone model

    // Update is called once per frame
    void Update()
    {
         if(gameObject.name == "Propeller_FR" || gameObject.name == "Propeller_RL")
              {transform.Rotate(Vector3.back * Time.deltaTime * 1000);}

         if(gameObject.name == "Propeller_FL" || gameObject.name == "Propeller_RR" ){
            transform.Rotate(Vector3.forward * Time.deltaTime * 1000);
              }

    }
}