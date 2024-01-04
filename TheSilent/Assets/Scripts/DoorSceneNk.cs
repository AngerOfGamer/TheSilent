using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSceneNk : MonoBehaviour
{
    [SerializeField] private string targetSceneName; // Nama scene yang akan dituju

    // Panggil ini dari tempat lain, seperti dari tombol atau metode lainnya
    public void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
