using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ControladorPausa : MonoBehaviour
{

    [SerializeField] GameObject MenuPanel;
    [SerializeField] KeyCode ActionKey;
    // Start is called before the first frame update


    private void Start()
    {
        Time.timeScale = 1f;
    }


    private void Update()
    {
        if (Input.GetKeyDown(ActionKey))
        {
            pause();
        }
    }
    void pause()
    {
        MenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resume()
    {
        MenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void loadScene(string SceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneName);

    }



}
