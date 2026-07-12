using UnityEngine;

public class LoadingCanvasManager : MonoBehaviour
{
    public static LoadingCanvasManager Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}