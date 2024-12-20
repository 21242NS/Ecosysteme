using System.Collections.ObjectModel;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public partial class Meat : GameObject {
    [ObservableProperty]
    private int fresh;
    public Meat(Point location):base(location) {
        this.fresh = 100;
    }
    public void turn_in_organique(){

    }
    public ObservableCollection<GameObject> Tick(ObservableCollection<GameObject>gameobjects){
        
        return gameobjects;
    }
}