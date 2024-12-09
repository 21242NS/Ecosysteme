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

    public Form_of_life( Point location):base(location) {
    }
    public virtual void eat(GameObject obj){
    }
    public virtual void reproduction(){

    }
    public virtual void is_dead(){

    }
}