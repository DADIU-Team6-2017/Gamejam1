using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    string m_TargetScene;

    public void LoadScene()
    {
        SceneManager.LoadScene(m_TargetScene);
    }
}
