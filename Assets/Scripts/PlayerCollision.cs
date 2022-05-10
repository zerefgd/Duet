using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(Constants.Tags.FINISH))
        {
            GameManager.instance.GameWin();
            return;
        }

        if (collision.gameObject.CompareTag(Constants.Tags.RESPAWN))
        {
            GameManager.instance.GameOver();
            return;
        }
    }
}
