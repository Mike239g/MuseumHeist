using UnityEngine;

public class TokenSpin : MonoBehaviour
{

    public float speed = 10f;
    
    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0f, speed * Time.deltaTime, 0f);
    }
}
