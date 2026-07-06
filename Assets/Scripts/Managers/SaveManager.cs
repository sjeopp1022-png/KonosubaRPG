using UnityEngine;

/// <summary>
/// 게임 저장/로드를 담당하는 매니저
/// (기초 구조 - PlayerPrefs 사용)
/// </summary>
public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

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

    /// <summary>
    /// 데이터 저장 (예: 골드)
    /// </summary>
    public void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// 데이터 불러오기 (기본값 포함)
    /// </summary>
    public int LoadInt(string key, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    /// <summary>
    /// 데이터 삭제
    /// </summary>
    public void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

    /// <summary>
    /// 전체 저장 삭제
    /// </summary>
    public void ClearAll()
    {
        PlayerPrefs.DeleteAll();
    }
}