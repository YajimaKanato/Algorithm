using UnityEngine;

[CreateAssetMenu(fileName = "CactusDefaultData", menuName = "Enemy/CactusDefaultData")]
public class CactusDefaultData : CharacterDefaultData
{
    public override void CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<CactusRuntimeData>(id, out _)) return;

        var data = new CactusRuntimeData(this);
        repository.RegisterData(id, data);
    }
}
