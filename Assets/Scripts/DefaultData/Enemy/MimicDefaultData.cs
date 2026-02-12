using UnityEngine;

[CreateAssetMenu(fileName = "MimicDefaultData", menuName = "Enemy/MimicDefaultData")]
public class MimicDefaultData : CharacterDefaultData
{
    public override CharacterRuntimeData CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<MimicRuntimeData>(id, out var data)) return data;

        data = new MimicRuntimeData(this);
        repository.RegisterData(id, data);
        return data;
    }

    public override void RemoveRuntimeData(RuntimeDataRepository repository, int id)
    {
        repository.RemoveData<MimicRuntimeData>(id);
    }
}
