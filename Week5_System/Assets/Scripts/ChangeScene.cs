using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTransition;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private bool LevelComplete = false;
    public TransitionSettings transition;
    public float loadDelay = .6f;
    public int CurrentScene = 0;
    public int NextScene = 0;

    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
        LevelComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(CurrentScene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            if (!LevelComplete) GoNextLevel();
        }
    }

    private void GoNextLevel()
    {
        LevelComplete = true;
        if (NextScene != 0) TransitionManager.Instance().Transition(0, transition, loadDelay);
    }
}
