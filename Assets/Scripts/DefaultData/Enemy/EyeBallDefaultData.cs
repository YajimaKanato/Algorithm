using UnityEngine;

[CreateAssetMenu(fileName = "EyeBallDefaultData", menuName = "Enemy/EyeBallDefaultData")]
public class EyeBallDefaultData : CharacterDefaultData
{
    public override CharacterRuntimeData CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<EyeBallRuntimeData>(id, out _)) return null;

        var data = new EyeBallRuntimeData(this);
        repository.RegisterData(id, data);
        return data;
    }
}
