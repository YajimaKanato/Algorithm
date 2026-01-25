using UnityEngine;

[CreateAssetMenu(fileName = "MushDefaultData", menuName = "Enemy/MushDefaultData")]
public class MushroomDefaultData : CharacterDefaultData
{
    public override void CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<MushroomRuntimeData>(id, out _)) return;

        var data = new MushroomRuntimeData(this);
        repository.RegisterData(id, data);
    }
}
