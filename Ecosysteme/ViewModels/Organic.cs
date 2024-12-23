using System.Collections.ObjectModel;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public partial class Organic : Not_a_life {
    [ObservableProperty]
    private int fresh;
    public Organic(Point location):base(location) {
        this.Fresh=100;
    }
    public ObservableCollection<GameObject> Tick(ObservableCollection<GameObject> gameobjects){
        if(Erased){
            gameobjects.Remove(this);
        }
        return gameobjects;
    }
}