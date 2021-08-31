using System.Linq;
using UnityEngine;

public class HabilityController : MonoBehaviour
{
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        var enemyHit = enemies.FirstOrDefault(m => m == other.gameObject);
        if (enemyHit != null)
            if (other.gameObject == enemyHit.gameObject)
            {
                Destroy(enemyHit);
            }

    }

}
