using UnityEngine;

public class MagusPool : CharacterPool
{
    [SerializeField] MagusDefaultData _data;

    public override CharacterInput Instantiate(CharacterInput character)
    {
        var go = Instantiate(character, new Vector3(0, 1, 1), Quaternion.identity);
        go.Init(_system, this);
        return go;
    }

    protected override void CreateRuntime(int id)
    {
        if (_repository.TryGetData<MagusRuntimeData>(id, out _)) return;

        var data = new MagusRuntimeData(_data);
        _repository.RegisterData(id, data);
    }
}
