using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public Transform playerTransform;
    public float speed = 4f;

    Rigidbody rigidbody;
    Collider collider;

    public bool following;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = player.GetComponent<Collider>();
        following = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (following)
            FollowPlayer();

    }

    private void OnTriggerStay(Collider other)
    {
        if (collider.tag == other.tag)
        {
            following = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (collider.tag == other.tag)
        {
            following = false;
        }
    }

    private void FollowPlayer()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.fixedDeltaTime);

        rigidbody.MovePosition(pos);
        transform.LookAt(playerTransform);
    }

}
