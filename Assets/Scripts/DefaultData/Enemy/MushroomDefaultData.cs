using UnityEngine;

[CreateAssetMenu(fileName = "MushDefaultData", menuName = "Enemy/MushDefaultData")]
public class MushroomDefaultData : CharacterDefaultData
{
    public override CharacterRuntimeData CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<MushroomRuntimeData>(id, out _)) return null;

        var data = new MushroomRuntimeData(this);
        repository.RegisterData(id, data);
        return data;
    }
}
