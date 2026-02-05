using UnityEngine;

[CreateAssetMenu(fileName = "CactusDefaultData", menuName = "Enemy/CactusDefaultData")]
public class CactusDefaultData : CharacterDefaultData
{
    public override CharacterRuntimeData CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<CactusRuntimeData>(id, out _)) return null;

        var data = new CactusRuntimeData(this);
        repository.RegisterData(id, data);
        return data;
    }
}
