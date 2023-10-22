using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class DollyTrackEndChecker : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;  // Asigna tu vCam aquí en el Inspector
    public string sceneToLoad;  // Asigna el nombre de la escena a cargar aquí en el Inspector

    private CinemachineTrackedDolly dolly;

    private void Start()
    {
        if (virtualCamera != null)
        {
            dolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        }
    }

    private void Update()
    {
        if (dolly != null)
        {
            if (dolly.m_PathPosition >= 30f)  // Si el recorrido está al final
            {
                ChangeScene();
            }
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
