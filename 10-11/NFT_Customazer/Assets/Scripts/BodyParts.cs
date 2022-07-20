using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyParts : MonoBehaviour
{
    public static BodyParts Instance { get; private set; }

    [SerializeField] private SpriteRenderer _head;
    [SerializeField] private SpriteRenderer _chest;
    [SerializeField] private SpriteRenderer _leftHand;
    [SerializeField] private SpriteRenderer _rightHand;
    [SerializeField] private SpriteRenderer _leftLeg;
    [SerializeField] private SpriteRenderer _rightLeg;

    void Awake() => Instance = this;

    public SpriteRenderer GetSpriteRenderer(BodyPart part)
    { 
        switch (part)
        {
            case BodyPart.Head: return _head;
            case BodyPart.Chest: return _chest;
            case BodyPart.LeftLeg: return _leftLeg;
            case BodyPart.RightLeg: return _rightLeg;
            case BodyPart.LeftHand: return _leftHand;
            case BodyPart.RightHand: return _rightHand;
        }

        throw new KeyNotFoundException($"No key name {part}");
    }
}
