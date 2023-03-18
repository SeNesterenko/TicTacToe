using UnityEngine;

[CreateAssetMenu]
public class Configuration : ScriptableObject
{
    public int LevelWidth => _levelWidth;
    public int LevelHeight => _levelHeight;
    public int WinChaneLenght => _winChaneLenght;
    public CellView CellView => _cellView;
    public Vector2 Offset => _offset;
    public SignView RingView => _ringView;
    public SignView CrossView => _crossView;

    [SerializeField] private int _levelWidth = 3;
    [SerializeField] private int _levelHeight = 3;
    [SerializeField] private int _winChaneLenght = 3;
    [SerializeField] private CellView _cellView;
    [SerializeField] private Vector2 _offset;
    [SerializeField] private SignView _ringView;
    [SerializeField] private SignView _crossView;
}