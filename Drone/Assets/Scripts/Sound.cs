using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    
    private AudioSource audioSource;
    public AudioClip hit_Zone_Electric;


    private void Start() {
          audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
  public void hit_Zone(){ audioSource.PlayOneShot(hit_Zone_Electric, 1.0f);}
}
