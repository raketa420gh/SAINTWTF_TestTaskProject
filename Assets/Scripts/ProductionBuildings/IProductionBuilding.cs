using System;

public interface IProductionBuilding
{
    event Action<string> OnStatusUpdated;

    void UpdateStatus(ProductionBuildingStatusType statusType);
}