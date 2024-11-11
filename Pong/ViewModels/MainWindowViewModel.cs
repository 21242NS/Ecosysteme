using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia;
using Pong.Model;
using System.Collections.ObjectModel;

namespace Pong.ViewModels;

public partial class MainWindowViewModel : GameBase
{
    public int Width { get; } = 800;
    public int Height { get; } = 450;

    [ObservableProperty]
    private Ball ball;

    public ObservableCollection<GameObject> GameObjects { get; } = new();

    public MainWindowViewModel() {
        Ball = new Ball(new Point(400, 225));
        GameObjects.Add(Ball);
    }

    protected override void Tick()
    {
        this.Ball.Tick();
    }
}
