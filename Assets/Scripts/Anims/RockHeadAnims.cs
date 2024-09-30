using UnityEngine;

public class RockHeadAnims : MonoBehaviour
{
    [SerializeField]
    bool bCanAtk = true;
    Animator animator;
    [SerializeField]
    GameObject stompAtkSensor;
    [SerializeField]
    GameObject stompAktTrigger;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void HabilitarAtk()
    {
        bCanAtk = true;
        if (stompAktTrigger == null) return;
        if (!stompAktTrigger.activeSelf) stompAktTrigger.gameObject.SetActive(true);
    }

    public void AtacarParaBaixo()
    {
        stompAktTrigger.SetActive(false);
        if (!bCanAtk) return;
        bCanAtk=false;
        animator.SetTrigger("IsAtkBottom");
    }

    public void ImpactoBottom()
    {
        animator.SetTrigger("hasStompped");
    }

    public void AtivarStompAkt()
    {
        stompAtkSensor.SetActive(true);
    }
    
    public void DesativarStompAtk()
    {
        stompAtkSensor.SetActive(false);
    }
}
