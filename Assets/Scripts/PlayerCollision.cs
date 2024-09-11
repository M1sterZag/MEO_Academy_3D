using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] GameObject panel;
    void Start()
    {
        panel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Board"))
        {
            panel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Board"))
        {
            panel.SetActive(false);
        }
    }
}
