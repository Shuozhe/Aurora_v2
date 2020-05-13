using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
  public void StartGame()
  {
    Debug.Log("StartGame");
    SceneManager.LoadScene(1);
  }

  public void ExitGame()
  {
    Debug.Log("ExitGame");
    Application.Quit();
  }

  public void StartDemo()
  {
    SceneManager.LoadScene(2);
  }

  public void GotoMenu()
  {
    SceneManager.LoadScene(0);
  }
}
