using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void OnHeadClick() => OnButtonClick(BodyPart.Head);
    public void OnChestClick() => OnButtonClick(BodyPart.Chest);
    public void OnLeftHandClick() => OnButtonClick(BodyPart.LeftHand);
    public void OnRightHandClick() => OnButtonClick(BodyPart.RightHand);
    public void OnLeftLegClick() => OnButtonClick(BodyPart.LeftLeg);
    public void OnRightLegClick() => OnButtonClick(BodyPart.RightLeg);

    private void OnButtonClick(BodyPart part)
    {
        AvailableParts sprites = Resources.Load(part.ToString()) as AvailableParts;
        SpriteRenderer renderer = BodyParts.Instance.GetSpriteRenderer(part);
        ContentController.Instance.UpdateButtonsList(sprites.Sprites, renderer);
    }
}
