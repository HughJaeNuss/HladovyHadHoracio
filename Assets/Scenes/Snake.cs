using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class Snake : MonoBehaviour      //add tail, fix speed, loading screen, game over screen, win screne, score, timer 
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments;
    private bool hasStarted = false; 

    public Transform segmentPrefab;
    public int initialSize = 4;

    public Sprite Head_up;
    public Sprite Head_right;
    public Sprite Head_down;
    public Sprite Head_left;

    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;
    private Stopwatch stopwatch; 
    public PlayerScore score; 
    public float eaten = 0;
    
    public float moveSpeed = 0.4f;
    public float speedIncreaseFactor = 0.02f;
    //public PlayerScore score;

    private void Start()
    {
            _segments = new List<Transform>();
            _segments.Add(this.transform);
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<Collider2D>();
            _collider.enabled = false; // Disable collision at the start
           score = FindFirstObjectByType<PlayerScore>(); // Get reference ONCE
           //score.StartScore();
           // if (score == null)
           // {
            //    Debug.LogError("PlayerScore script not found in the scene!");
            //} 
            stopwatch = FindFirstObjectByType<Stopwatch>(); // Get reference ONCE
            //Debug.LogError("Snake::Start Stopwatch elapsed:" + stopwatch.elapsedTime);
            if (stopwatch == null)
            {
                Debug.LogError("Stopwatch script not found in the scene!");
            } 

            for (int i = 1; i < initialSize; i++){
                Grow();
            }   
    }

    private void Update()
    {
        //Debug.LogError("Snake::Update Stopwatch elapsed:" + stopwatch.elapsedTime);
        if (Input.GetKeyDown(KeyCode.W)){       //stisknu klavesu a had se posune
            _direction = Vector2.up;
            _spriteRenderer.sprite = Head_up;
            StartMovement();
        }else if (Input.GetKeyDown(KeyCode.S)){
            _direction = Vector2.down;
            _spriteRenderer.sprite = Head_down;
            StartMovement();
        } else if (Input.GetKeyDown(KeyCode.A)){
            _direction = Vector2.left;
            _spriteRenderer.sprite = Head_left;
            StartMovement();
        } else if (Input.GetKeyDown(KeyCode.D)){
            _direction = Vector2.right;
            _spriteRenderer.sprite = Head_right;
            StartMovement();
        }
    }

     private void StartMovement()
    {
        if (!hasStarted)
        {    
            hasStarted = true;
            _collider.enabled = true; // Enable collision after movement starts
        }
        if (stopwatch != null) // Ensure stopwatch exists
            {
                stopwatch.StartTimer();
                score.StartScore();
                //Debug.LogError("Snake::Start Stopwatch elapsed:" + stopwatch.elapsedTime + score.PlayerScoreText.text);
            }
        if (score != null) // Ensure score exists
            {
               score.StartScore();
            }
 
    }

    private void FixedUpdate()      //fyzikalni veci, vyplyva z pouziti RigidBody 2D
    {
            if (!hasStarted) return;
            for (int i = _segments.Count - 1; i > 0; i--)       //posledni segment se posune na pozici toho pred nim
            {
                _segments[i].position = _segments[i - 1].position;
            }

            this.transform.position = new Vector3(
                Mathf.Round(this.transform.position.x) + _direction.x,
                Mathf.Round(this.transform.position.y) + _direction.y,
                0.0f
            );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
        moveSpeed = Mathf.Max(0.05f, moveSpeed - speedIncreaseFactor);
    }

    private void ResetState()
    {
        for (int i = 1; i <_segments.Count; i++){
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < this.initialSize; i++){
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        moveSpeed = 0.5f;
        this.transform.position = Vector3.zero;
        _direction = Vector2.zero; // Stop movement
        hasStarted = false; // Reset movement flag
        _collider.enabled = false; // Disable collision until movement starts
    }

    private void OnTriggerEnter2D(Collider2D other)     //zavola se, kdyz dojde ke kolizi
    {
        if (other.tag == "Food"){         //kontrola, jestli had je ten objekt, ktery narazil do jidla, tady by to byt nemuselo, ale je to lepsi setrit stejne
           Grow(); 
           eaten++;
        } else if (other.tag == "Obstacle"){
            stopwatch.StopTimer();
            PlayerPrefs.SetFloat("eaten", eaten);
            PlayerPrefs.Save();
            ResetState();
            SceneManager.LoadScene("GOMenu", LoadSceneMode.Single);
        }
    }
}
