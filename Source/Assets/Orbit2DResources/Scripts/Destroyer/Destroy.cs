using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == name)
        {

            return;
        }
        else
        {
            if (other.gameObject.transform.parent)
            {

                Destroy(other.gameObject.transform.parent.gameObject);
                Debug.Log("Destroy " + other.gameObject.transform.parent.name);
            }
            else
            {
                if (other.gameObject.name != "ScoreKeeper")
                {
                    Destroy(other.gameObject);

                }
            }
        }
    }
}
