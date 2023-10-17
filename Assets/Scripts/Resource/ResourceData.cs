using UnityEngine;

[CreateAssetMenu(order = 51, menuName = "Resource", fileName = "ResourceData")]

public class ResourceData : ScriptableObject
{
    [SerializeField] private Color _color = Color.white;
    [SerializeField] private ResourceType _type;

    public Color Color => _color;
    public ResourceType Type => _type;
}