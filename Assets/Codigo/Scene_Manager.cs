using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public static Scene_Manager main { get; private set; }

    public void LoadedScene(string name) => GoToScene(name);
    public void ReloadScene() => GoToScene(SceneManager.GetActiveScene().name);
    public void Link(string url) => Application.OpenURL(url);
    private void Awake()
    {
        if (main == null)
            main = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    public void ExitGame()
    {
        
        Application.Quit();
    }
    public void LoadMenu()
    {
        GoToScene("Menu");
        
    }
    private void GoToScene(string scenename)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scenename);
    }
    
}
