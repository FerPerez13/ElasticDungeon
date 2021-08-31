using UnityEngine;

public class PreviewController : MonoBehaviour
{

    public Transform Player;

    public GameObject Preview;
    public GameObject Text;
    public GameObject Enemy;
    public GameObject Sword;

    public bool showPreview = false;
    public float chargeVelocity = 0.1f;
    public float maxCharge = 1;

    MeshRenderer previewRenderer;
    MeshRenderer textRenderer;
    Transform previewTransform;

    Vector3 originalPreviewScale;
    Vector3 originalPreviewPosition;

    private bool canDoDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        this.previewRenderer = Preview.GetComponent<MeshRenderer>();
        this.textRenderer = Text.GetComponent<MeshRenderer>();
        this.previewTransform = Preview.GetComponent<Transform>();

        this.originalPreviewScale = previewTransform.localScale;
        this.originalPreviewPosition = previewTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Sword.SetActive(false);
        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            this.showPreview = true;
        }
        if (Input.GetKeyUp(KeyCode.K) || Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            ControlPreviewAttack();

            if (canDoDamage)
                ReleaseHability();

            this.showPreview = false;
        }

        previewRenderer.enabled = this.showPreview;

        ControlPreviewScale();
    }

    private void ControlPreviewAttack()
    {
        if (previewTransform.localPosition.z >= 5)
        {
            var x = previewTransform.position.x;
            if (x < 2)
                x = 2;
            if (x > 46)
                x = 46;

            var z = previewTransform.position.z;
            if (z < 2)
                z = 2;
            if (z > 46)
                z = 46;

            Player.position = new Vector3(x, Player.position.y, z);
        }
    }

    private void ControlPreviewScale()
    {
        if (this.showPreview)
        {
            if (previewTransform.localScale.z < maxCharge)
            {
                previewTransform.localScale = new Vector3(previewTransform.localScale.x, previewTransform.localScale.y, previewTransform.localScale.z + chargeVelocity);
                previewTransform.localPosition = new Vector3(previewTransform.localPosition.x, previewTransform.localPosition.y, previewTransform.localPosition.z + 5 * chargeVelocity);

            }

            // Cambio de color dependiendo de la fuerza del ataque            
            if (previewTransform.localPosition.z < 4)
            {
                previewRenderer.material.SetColor("_Color", Color.yellow);
            }
            else if (previewTransform.localPosition.z >= 4 && previewTransform.localPosition.z < 5)
            {
                previewRenderer.material.SetColor("_Color", Color.green);
                this.canDoDamage = true;

            }
            else
            {
                if (this.showPreview)
                    textRenderer.enabled = true;

                previewRenderer.material.SetColor("_Color", Color.red);
            }
        }
        else
        {
            textRenderer.enabled = false;
            previewTransform.localScale = originalPreviewScale;
            previewTransform.localPosition = originalPreviewPosition;
        }


    }

    private void ReleaseHability()
    {
        Sword.SetActive(true);
    }
}
