using System;
using UnityEngine;

[RequireComponent(typeof(UIProductionBuildingStatus))]

public abstract class ProductionBuilding : MonoBehaviour, IProductionBuilding
{
    [SerializeField] private string _workStatusText = "Работает";
    [SerializeField] private string _stopIsFullStatusText = "Остановлено. Полный исходящий склад";
    [SerializeField] private string _stopNoCunsumptionStatusText = "Остановлено. Не хватает ресурсов на складе";
    private IUIProductionBuildingStatus _buildingStatus;
        
    public event Action<string> OnStatusUpdated;

    protected virtual void Awake()
    {
        _buildingStatus = GetComponent<IUIProductionBuildingStatus>();
    }

    public void UpdateStatus(ProductionBuildingStatusType statusType)
    {
        string statusText = new string("");

        switch (statusType)
        {
            case ProductionBuildingStatusType.Work:
                statusText = _workStatusText;
                break;
            case ProductionBuildingStatusType.StopIsFull:
                statusText = _stopIsFullStatusText;
                break;
            case ProductionBuildingStatusType.StopNoConsumption:
                statusText = _stopNoCunsumptionStatusText;
                break;
        }

        OnStatusUpdated?.Invoke(statusText);
    }
}