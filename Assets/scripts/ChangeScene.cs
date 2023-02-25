public class ChangeScene : MonoBehaviour 
{  
    public void loadNextScene (string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
    }
}
