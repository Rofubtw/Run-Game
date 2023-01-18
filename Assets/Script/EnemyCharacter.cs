using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCharacter : MonoBehaviour
{
    public GameObject AttackTarget;
    [SerializeField] NavMeshAgent _nawMesh;
    [SerializeField] Animator _animator;
    [SerializeField] GameManager _gameManager;
    bool _isAttacking = false;
    public void TriggerAnimation()
    {
        _animator.SetBool("Attack",true);
        _isAttacking = true;
    }
    void LateUpdate()
    {
        if (!_isAttacking) return;
        _nawMesh.SetDestination(AttackTarget.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UnderCharacters"))
        {
            Vector3 NewPosition = new Vector3(transform.position.x, .23f, transform.position.z);
            _gameManager.CreateExtinctionEffect(NewPosition,false,true);
            gameObject.SetActive(false);            
        }
    }
}
