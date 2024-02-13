using UnityEngine;

public class GoalCounter : MonoBehaviour
{
    public int CurrentScore = 0; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            
            CurrentScore++;
            Destroy(collision.gameObject);
        }
    }


}