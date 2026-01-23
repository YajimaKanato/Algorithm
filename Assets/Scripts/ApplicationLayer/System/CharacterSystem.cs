using DataDriven;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterSystem
{
    RuntimeDataRepository _repository;
    Dictionary<CharacterView, Vector3[]> _dict;

    public CharacterSystem(RuntimeDataRepository repository)
    {
        _repository = repository;
        _dict = new Dictionary<CharacterView, Vector3[]>();
    }

    public void Move(int id, CharacterInput input, CharacterView view, Node target)
    {
        if (!_repository.TryGetData<CharacterRuntimeData>(id, out var data)) return;

        NavMeshPath nav = new NavMeshPath();
        Vector3[] path = new Vector3[16];
        Debug.Log($"{NavMesh.AllAreas} {nav}");
        NavMesh.CalculatePath(view.transform.position, target.transform.position, NavMesh.AllAreas, nav);
        int count = nav.GetCornersNonAlloc(path);
        Debug.Log(string.Join(",", path));
        _dict[view] = path;
        input.NodeSizeSetting(count);
    }

    public Vector3 MoveSetting(int id, CharacterView view, int index)
    {
        if (!_repository.TryGetData<CharacterRuntimeData>(id, out var data)) return Vector3.zero;
        var vecs = _dict[view];
        view.Move(vecs[index], vecs[index + 1], data.Speed);
        return vecs[index + 1];
    }

    public void Move(CharacterView view, Vector3 target)
    {
        view.Move(target, Vector3.zero, 0);
    }
}
