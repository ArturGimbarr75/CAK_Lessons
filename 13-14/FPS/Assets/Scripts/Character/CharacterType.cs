using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[DisallowMultipleComponent]
public class CharacterType : MonoBehaviour
{
    public Type ObjectType => _type;
    public static event Action<Type> OnCharactersCountChanged;
    [SerializeField] private Type _type;
    private static HashSet<CharacterType> _objectsPool = new HashSet<CharacterType>();

    void OnEnable()
    {   
        if (!_objectsPool.Contains(this))
        {
            _objectsPool.Add(this);
            OnCharactersCountChanged?.Invoke(ObjectType);
        }
    }

    void OnDisable()
    {
        if (_objectsPool.Contains(this))
        { 
            _objectsPool.Remove(this);
            OnCharactersCountChanged?.Invoke(ObjectType);
        }
    }

    public static IEnumerable<CharacterType> GetAllObjectsOfType(Type type)
        => _objectsPool?.Where(x => type.HasFlag(x.ObjectType));

    public enum Type
    {
        Player = 0b1,
        Turret = 0b10
    }
}