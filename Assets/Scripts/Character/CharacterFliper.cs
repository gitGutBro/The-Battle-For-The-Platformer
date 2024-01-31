using UnityEngine;

public class CharacterFliper : MonoBehaviour
{
    private bool _facingRight = true;

    public void TryFlip(float position)
    {
        if (position > 0 && _facingRight == false)
            Flip();

        if (position < 0 && _facingRight)
            Flip();
    }

    private void Flip()
    {
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        _facingRight = !_facingRight;
    }
}