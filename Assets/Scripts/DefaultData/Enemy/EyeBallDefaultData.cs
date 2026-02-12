using UnityEngine;

[CreateAssetMenu(fileName = "EyeBallDefaultData", menuName = "Enemy/EyeBallDefaultData")]
public class EyeBallDefaultData : CharacterDefaultData
{
    public override CharacterRuntimeData CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<EyeBallRuntimeData>(id, out var data)) return data;

        data = new EyeBallRuntimeData(this);
        repository.RegisterData(id, data);
        return data;
    }

    public override void RemoveRuntimeData(RuntimeDataRepository repository, int id)
    {
        repository.RemoveData<EyeBallRuntimeData>(id);
    }
}
