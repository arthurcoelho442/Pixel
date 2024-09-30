using UnityEngine;
using UnityEngine.Events;

public class EventoAlavanca : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    public EventEfeitoAlavanca efeito;

    public void Acionar()
    {
        animator.SetTrigger("IsActive");
    }

    public void InvocarEfeito()
    {
        efeito.Invoke(true);
    }
}


[System.Serializable]
public class EventEfeitoAlavanca : UnityEvent<bool> { }
