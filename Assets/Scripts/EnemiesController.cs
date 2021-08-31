using System.Linq;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public int count = 0;

    public GameObject[] enemies;

    public bool winner = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        count = enemies.Where(m => m != null).ToList().Count;
        if (count == 0)
            winner = true;
    }
}
