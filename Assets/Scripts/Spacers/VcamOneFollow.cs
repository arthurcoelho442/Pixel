using Cinemachine;
using UnityEngine;

public class VcamOneFollow : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera vcam;

    private void OnEnable()
    {
        vcam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
