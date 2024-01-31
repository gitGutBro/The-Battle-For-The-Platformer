using UnityEngine;

public static class CharacterAnimatorData
{
    public static class Params
    {
        public static readonly int HorizontalMove = Animator.StringToHash(nameof(HorizontalMove));
        public static readonly int Jumping = Animator.StringToHash(nameof(Jumping));
        public static readonly int Die = Animator.StringToHash(nameof(Die));
        public static readonly int Hit = Animator.StringToHash(nameof(Hit));
    }
}