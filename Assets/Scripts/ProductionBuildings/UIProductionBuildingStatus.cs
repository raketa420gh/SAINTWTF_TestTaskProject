using TMPro;
using UnityEngine;

public class UIProductionBuildingStatus : MonoBehaviour, IUIProductionBuildingStatus
{
    [SerializeField] private ProductionBuilding _productionBuilding;
    [SerializeField] private TMP_Text _buildingStatusText;

    private void OnEnable()
    {
        _productionBuilding.OnStatusUpdated += HandleUpdateStatusEvent;
    }

    private void OnDisable()
    {
        _productionBuilding.OnStatusUpdated -= HandleUpdateStatusEvent;
    }

    private void HandleUpdateStatusEvent(string text)
    {
        _buildingStatusText.text = text;
    }
}