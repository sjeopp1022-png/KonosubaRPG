using UnityEngine;

/// <summary>
/// 게임 전체 흐름을 관리하는 핵심 매니저
/// (싱글톤 구조 - 어디서든 접근 가능하게 만들 예정)
/// </summary>
public class GameManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static GameManager Instance;

    [Header("게임 상태")]
    public bool isGameStarted = false;

    private void Awake()
    {
        // 싱글톤 초기화
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 이동해도 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Debug.Log("GameManager 시작됨");
        isGameStarted = true;
    }

    /// <summary>
    /// 게임 시작 처리
    /// </summary>
    public void StartGame()
    {
        isGameStarted = true;
        Debug.Log("게임 시작!");
    }

    /// <summary>
    /// 게임 종료 처리
    /// </summary>
    public void EndGame()
    {
        isGameStarted = false;
        Debug.Log("게임 종료!");
    }
}