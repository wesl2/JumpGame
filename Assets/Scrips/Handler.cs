using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Handler : MonoBehaviour
{
    [SerializeField] float DelayTime = 1f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;
    AudioSource AS;



    bool IsCollision = true;
    bool IsTransition = false;
    private void Start()
    {
        AS = GetComponent<AudioSource>();
    }
    private void Update()
    {
        SkipLevel();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (IsTransition == true || IsCollision ==false) { return; }

        switch (collision.gameObject.tag)
            {
                case "Friendly":
                    break;
                case "Finish":
                    StartSuccessSequence();
                    break;
                default:
                    StartCrashSequence(DelayTime);
                    break;
            }
          
    }
    void SkipLevel()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            IsCollision = !IsCollision;
        }
    }
    void StartSuccessSequence()
    {
        IsTransition = true;
       Invoke("LoadNextLevel", 0.6f);
            AS.PlayOneShot(success);
         
     }

    void StartCrashSequence(float D_T)
    {
         IsTransition = true;
        GetComponent<jump>().enabled = false;
         Invoke("ReloadLevel", D_T);
        AS.PlayOneShot(crash);
    }
    void  ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int NextSceneIndex = currentSceneIndex + 1;
        if(NextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            NextSceneIndex = 0;
        }
        SceneManager.LoadScene(NextSceneIndex);
    }
}
