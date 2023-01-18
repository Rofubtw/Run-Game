using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    [SerializeField] GameObject Target;
    [SerializeField] GameManager gameManager;
    [SerializeField] NavMeshAgent _nawMesh;
    public Rigidbody Rigidbody { get; set; }

    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void LateUpdate() => _nawMesh.SetDestination(Target.transform.position);

    Vector3 GivePosition() 
    { 
        return new Vector3(transform.position.x, .23f, transform.position.z); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pinBox"))
        {
            gameManager.CreateExtinctionEffect(GivePosition());
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Chainsaw"))
        {
            gameManager.CreateExtinctionEffect(GivePosition());
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Propeller"))
        {
            gameManager.CreateExtinctionEffect(GivePosition());
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Hammer"))
        {
            gameManager.CreateExtinctionEffect(GivePosition(),true);
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Enemy"))
        {
            gameManager.CreateExtinctionEffect(GivePosition(),false,false);
            gameObject.SetActive(false);
        }
        if (other.CompareTag("EmptyCharacters"))
        {
            gameManager.Characters.Add(other.gameObject);
        }
    }
}
