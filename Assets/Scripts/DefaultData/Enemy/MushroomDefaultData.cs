using UnityEngine;

[CreateAssetMenu(fileName = "MushDefaultData", menuName = "Enemy/MushDefaultData")]
public class MushroomDefaultData : CharacterDefaultData
{
    public override CharacterRuntimeData CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<MushroomRuntimeData>(id, out var data)) return data;

        data = new MushroomRuntimeData(this);
        repository.RegisterData(id, data);
        return data;
    }

    public override void RemoveRuntimeData(RuntimeDataRepository repository, int id)
    {
        repository.RemoveData<MushroomRuntimeData>(id);
    }
}
