using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public partial class Organic : GameObject {
    [ObservableProperty]
    private int fresh;
    public Organic(Point location):base(location) {
        this.Fresh=100;
    }
    public void Tick(){
        
    }
}