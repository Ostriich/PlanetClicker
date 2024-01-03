using UnityEngine;

public class ClickTextBehaviour : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyObject", 2);
    }

    private void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0, 0.025f, 0);
        gameObject.GetComponent<TextMesh>().color -= new Color32(0,0,0,5);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
