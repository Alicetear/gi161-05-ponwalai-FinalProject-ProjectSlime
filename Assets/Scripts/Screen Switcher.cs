using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public void OpenScene (int index)
    {
        SceneManager.LoadScene (index);
    }
}
