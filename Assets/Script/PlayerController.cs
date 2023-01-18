using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] Slider _slider;
    [SerializeField] GameObject _lastTrigger;

    public Cam Cam;
    public bool IsItEnd;
    public GameObject CharacterDestination;
    const float _minX = -1.01f;
    const float _maxX = 1.04f;

    private void Start()
    {
        float distance = Vector3.Distance(transform.position,_lastTrigger.transform.position);
        _slider.maxValue = distance;
    }

    void Update() => PlayerUpdateMovement();

    void LateUpdate() => PlayerLimitation(_minX, _maxX);
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Multiplication") || other.CompareTag("Collection") || other.CompareTag("Subtraction") || other.CompareTag("Division"))
        {
            int _number = int.Parse(other.name);
            _gameManager.CharacterNumberChange(other.tag, _number, other.transform);
        }
        else if (other.CompareTag("LastTrigger"))
        {
            Cam.EndCamPosition=true;
            IsItEnd = true;
            _gameManager.TriggerEnemy();
        }
        else if (other.CompareTag("EmptyCharacters"))
        {
            _gameManager.Characters.Add(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pole") || collision.gameObject.CompareTag("pinBox") || collision.gameObject.CompareTag("Propeller"))
        {
            if (transform.position.x > 0)
                transform.position = new Vector3(transform.position.x - .2f, transform.position.y, transform.position.z);
            else
                transform.position = new Vector3(transform.position.x + .2f, transform.position.y, transform.position.z);
        }
    }
    private void PlayerLimitation(float minX, float maxX)
    {
        Vector3 viewPos = transform.localPosition;
        viewPos.x = Mathf.Clamp(viewPos.x, minX, maxX);
        transform.localPosition = viewPos;
    }
    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Input.GetAxis("Mouse X") < 0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z), .3f);
            }
            if (Input.GetAxis("Mouse X") > 0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), .3f);
            }
        }
    }
    private void PlayerUpdateMovement()
    {
        if (Time.timeScale == 0) return;
        if (IsItEnd)
        {
            transform.position = Vector3.Lerp(transform.position, CharacterDestination.transform.position, .015f);
            if (_slider.value != 0)
                _slider.value -= .01f;
        }
        else
        {
            float distance = Vector3.Distance(transform.position, _lastTrigger.transform.position);
            _slider.value = distance;
            PlayerMovement();
        }
        transform.Translate(Vector3.forward * .5f * Time.deltaTime);
    }
    
}
