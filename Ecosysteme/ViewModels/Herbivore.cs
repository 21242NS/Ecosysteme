using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public abstract partial class Herbivore : Animals {
    

    public Herbivore(Point location) : base(location) {

    }

    public override void eat(GameObject obj)
    {
        if (obj is Plants){
            Plants plants = (Plants)obj;
            if (this.Point_of_life==this.Maximum_point_of_life&& this.Energy_count< this.Maximum_energy){
                this.Energy_count += 5;
            }
            else {
                this.Point_of_life += 5;
                if (this.Point_of_life>this.Maximum_point_of_life){
                    this.Point_of_life = this.Maximum_point_of_life;
                }
            }
            plants.is_dead();
        }
    }
}