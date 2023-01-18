using Rauf;
using UnityEngine;
using UnityEngine.AI;

public class EmptyCharacter : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _renderer;
    [SerializeField] private Material _assignedMaterial;
    [SerializeField] NavMeshAgent _nawMesh;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject Target;
    [SerializeField] GameManager gameManager;
    bool _isContact = false;
    MemoryManagement _memoryManagement = new MemoryManagement();
    private void LateUpdate() 
    {
        if (!_isContact) return;
            _nawMesh.SetDestination(Target.transform.position);
        if (!gameManager.isgameover) return;
            _animator.SetBool("Attack", false);        
    }
    Vector3 GivePosition()
    {
        return new Vector3(transform.position.x, .23f, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UnderCharacters")||other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("EmptyCharacters"))
            {
                ChangeMaterial();
                _isContact = true;
            }
        }
        if (other.CompareTag("Enemy"))
        {
            gameManager.CreateExtinctionEffect(GivePosition(), false, false);
            gameObject.SetActive(false);
            gameManager.Characters.Remove(gameObject);
        }
        if (other.CompareTag("pinBox"))
        {
            gameManager.CreateExtinctionEffect(GivePosition());
            gameObject.SetActive(false);
            gameManager.Characters.Remove(gameObject);
        }
        if (other.CompareTag("Chainsaw"))
        {
            gameManager.CreateExtinctionEffect(GivePosition());
            gameObject.SetActive(false);
            gameManager.Characters.Remove(gameObject);
        }
        if (other.CompareTag("Propeller"))
        {
            gameManager.CreateExtinctionEffect(GivePosition());
            gameObject.SetActive(false);
            gameManager.Characters.Remove(gameObject);
        }
        if (other.CompareTag("Hammer"))
        {
            gameManager.CreateExtinctionEffect(GivePosition(), true);
            gameObject.SetActive(false);
            gameManager.Characters.Remove(gameObject);
        }
    }
    void ChangeMaterial() 
    {
        Material[] mats = _renderer.materials;
        mats[0] = _assignedMaterial;
        _renderer.materials = mats;
        gameObject.GetComponent<AudioSource>().volume = _memoryManagement.ReadFloatData("GameFx");
        gameObject.GetComponent<AudioSource>().Play();
        _animator.SetBool("Attack", true);
        gameObject.tag = "UnderCharacters";
        GameManager.MomentaryCharacterNumber++;
        gameManager.Characters.Add(gameObject);
        //Debug.Log(GameManager.MomentaryCharacterNumber);
    }
}
