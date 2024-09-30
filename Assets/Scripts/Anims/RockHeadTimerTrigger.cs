using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class RockHeadTimerTrigger  : MonoBehaviour
{
    [SerializeField]
    List<EventStompAtkTrigger> stompAtkTriggers;
    [SerializeField]
    float intervaloEntreQuedas = 1.0f;
    
    private Coroutine cicloDeQueda;

    private void OnEnable() {
        if (cicloDeQueda == null) {
            cicloDeQueda = StartCoroutine(IniciarCicloDeQueda());
        }
    }
    private void OnDisable() {
        if (cicloDeQueda != null) {
            StopCoroutine(cicloDeQueda);
            cicloDeQueda = null;
        }
    }

    private IEnumerator IniciarCicloDeQueda(){
        while(true){
            yield return new WaitForSeconds(intervaloEntreQuedas);
            HandleInitAttack();
        }
    }
    private void HandleInitAttack(){
        foreach (var trigger in stompAtkTriggers) {
            trigger.Invoke(true);
        }
    }
}

[System.Serializable]
public class EventStompAtkTrigger : UnityEvent<bool> { }