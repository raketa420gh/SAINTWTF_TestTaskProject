using UnityEngine;

public static class AssetPath
{
    public const string UIController = "Prefabs/UIController";
    public const string PickableItem = "Prefabs/Items/PickableItem";
    public const string PickupVFX_1 = "Prefabs/FX/PickupVFX_1";
    public const string PickupVFX_2 = "Prefabs/FX/PickupVFX_2";
    public const string PickupVFX_3 = "Prefabs/FX/PickupVFX_3";
    public const string PickupVFX_4 = "Prefabs/FX/PickupVFX_4";
    public const string PickupVFX_5 = "Prefabs/FX/PickupVFX_5";
    public const string PickupVFX_6 = "Prefabs/FX/PickupVFX_6";
    public const string PickupVFX_7 = "Prefabs/FX/PickupVFX_7";
    public const string PickupVFX_8 = "Prefabs/FX/PickupVFX_8";
    public const string PickupVFX_9 = "Prefabs/FX/PickupVFX_9";
    public const string PickupVFX_10 = "Prefabs/FX/PickupVFX_10";
    public const string PickupVFX_11 = "Prefabs/FX/PickupVFX_11";
    public const string PickupVFX_12 = "Prefabs/FX/PickupVFX_12";
    public const string PickupVFX_13 = "Prefabs/FX/PickupVFX_13";
    public const string PickupVFX_14 = "Prefabs/FX/PickupVFX_14";
    
    private static int _pickupVFXIndex = 0;

    private static string[] _pickupVFXpathes = new[]
    {
        PickupVFX_3, PickupVFX_4,
        PickupVFX_5, PickupVFX_6, PickupVFX_7,
        PickupVFX_8, PickupVFX_9, PickupVFX_10,
        PickupVFX_11, PickupVFX_12
    };
    

    public static string GetRandomPickUpVFXPath()
    {
        var rIndex = Random.Range(0, _pickupVFXpathes.Length);

        return _pickupVFXpathes[rIndex];
    }

    public static string GetNextPickupVFXPath()
    {
        var path = _pickupVFXpathes[_pickupVFXIndex];

        _pickupVFXIndex++;

        if (_pickupVFXIndex >= _pickupVFXpathes.Length)
            _pickupVFXIndex = 0;
        
        return path;
    }
}