using UnityEngine;

[CreateAssetMenu(fileName = "CactusDefaultData", menuName = "Enemy/CactusDefaultData")]
public class CactusDefaultData : CharacterDefaultData
{
    public override CharacterRuntimeData CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<CactusRuntimeData>(id, out var data)) return data;

        data = new CactusRuntimeData(this);
        repository.RegisterData(id, data);
        return data;
    }

    public override void RemoveRuntimeData(RuntimeDataRepository repository, int id)
    {
        repository.RemoveData<CactusRuntimeData>(id);
    }
}
