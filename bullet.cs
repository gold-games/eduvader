using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public float speed = 1.0f;
    private Vector3 target;

    // Use this for initialization
    void Start()
    {
        this.target = this.transform.position + new Vector3(0, 20, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = this.transform.position;
        Vector3 newPosition = Vector3.MoveTowards(currentPosition, this.target, speed * Time.deltaTime);
        this.transform.position = newPosition;
        if (this.transform.position.y > 4.8f)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
