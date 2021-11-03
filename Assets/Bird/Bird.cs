using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;
    private float _timeSittingAround;
    private bool _birdWasLaunched;

    [SerializeField] private float _launchPower = 500;

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Start()
    {

    }

    private void Update()
    {

        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);

        if (_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }

        Vector3 currentPosition = transform.position;
        if (currentPosition.y > 10 ||
            currentPosition.y < -10 ||
            currentPosition.x > 10 ||
            currentPosition.x < -10 ||
            _timeSittingAround > 3)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<LineRenderer>().enabled = false;
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;

    }

    private void OnMouseDrag()
    {
        Vector3 newPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPostion.x, newPostion.y, 0);
    }
}
