using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCol : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            SceneManager.LoadScene(2);
    }
}
