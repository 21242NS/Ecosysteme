using System.Collections.ObjectModel;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public abstract partial class Form_of_life : GameObject {
    [ObservableProperty]
    private int point_of_life;
    [ObservableProperty]
    private int energy_count;
    [ObservableProperty]
    private int defense;
    [ObservableProperty]
    private int maximum_energy;
    [ObservableProperty]
    private int maximum_point_of_life;
     [ObservableProperty]
    private int count =0;
    


    public Form_of_life( Point location):base(location) {
    }
    public virtual void eat(GameObject obj){
    }
    public virtual Form_of_life reproduction(int time_of_reproduction){
        return this;
    }
  
    public virtual ObservableCollection<GameObject> Tick(ObservableCollection<GameObject>gameobjects, int Height, int Width){
        return gameobjects;
    }
    
}