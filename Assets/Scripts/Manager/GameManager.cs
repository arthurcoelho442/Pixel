using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    GameObject[] cams;
    [SerializeField]
    CinemachineVirtualCamera camAtual;
    [SerializeField]
    CinemachineBrain brain;
    List<CinemachineVirtualCamera> camList = new List<CinemachineVirtualCamera>();

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        CriarCam(0);
        LoadScene("Principal", LoadSceneMode.Additive);
    }


    public void LoadScene(string sceneName, LoadSceneMode mode)
    {
        if(sceneName == "MudarCam")return;
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName, mode);
    }

    public void CriarCam(int camId)
    {
        if (camAtual != null)
        {
            camAtual.gameObject.SetActive(false);
        }
        camAtual = Instantiate(cams[camId]).GetComponent<CinemachineVirtualCamera>();
        camList.Add(camAtual);
        if(camList.Count > 1)
        {
            for (int i = 0; i < camList.Count-1; i++)
            {
                if (camList[i] == camAtual) continue;
                Destroy(camList[i].gameObject);
                camList.Clear();
                camList.Add(camAtual);
            }
        }
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene == SceneManager.GetSceneByBuildIndex(0) && mode == LoadSceneMode.Single)
        {
            LoadScene("Principal", LoadSceneMode.Additive);
            camList = new List<CinemachineVirtualCamera>();
            CriarCam(0);
        }
    }
}
