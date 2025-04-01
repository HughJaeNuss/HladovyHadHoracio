using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;

    public AudioSource Crunch;

    private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()        //náhodný generátor jídla v rámci vymezené plochy
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)     //zavola se, kdyz dojde ke kolizi
    {
        if (other.tag == "Player"){         //kontrola, jestli had je ten objekt, ktery narazil do jidla, tady by to byt nemuselo, ale je to lepsi setrit stejne
           RandomizePosition(); 
            Crunch.Play();
        } 
    }
}
