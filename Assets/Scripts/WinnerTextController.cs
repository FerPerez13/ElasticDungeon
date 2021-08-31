using UnityEngine;

public class WinnerTextController : MonoBehaviour
{
    public Transform playerTransform;
    public EnemiesController enemiesController;

    MeshRenderer textRenderer;

    // Start is called before the first frame update
    void Start()
    {
        textRenderer = GetComponent<MeshRenderer>();
        textRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesController.winner)
            textRenderer.enabled = true;

        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 3, playerTransform.position.z);
    }
}
