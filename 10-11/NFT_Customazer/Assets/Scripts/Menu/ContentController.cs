using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ContentController : MonoBehaviour
{
    public static ContentController Instance { get; private set; }

    [SerializeField] private Button _buttonPrefab;

    void Awake() => Instance = this;

    public void UpdateButtonsList(Sprite[] sprites, SpriteRenderer renderer)
    {
        int index = transform.childCount;
        while (index --> 0)
        {
            Transform child = transform.GetChild(index);
            if (child.gameObject.activeSelf)
                Destroy(child.gameObject);
        }
        
        foreach (Sprite sprite in sprites)
        {
            Button temp = Instantiate(_buttonPrefab.gameObject).GetComponent<Button>();
            temp.transform.SetParent(transform, false);
            temp.gameObject.SetActive(true);
            Sprite s = sprite;
            temp.transform.GetChild(0).GetComponent<Image>().sprite = s;
            temp.onClick.AddListener(delegate () { renderer.sprite = s; });
        }
    }
}
