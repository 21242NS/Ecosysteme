using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public partial class Rose : Plants {
    private int maximum_energy=35;
    private int count = 0;
    public Rose(Point location): base(location) {
        this.Point_of_life = 100;
        this.Energy_count= 35;
        this.Defense= 3;
        this.Range_of_food = 5;
        this.Type = "Plants";
    }
    public override void eat()
    {
        if (this.Energy_count < maximum_energy){

        }
    }
    public override void reproduction()
    {
        if(count%1000==0){
            Point new_location = Location + new Point(1.0,0);
            new Rose(new_location);
        }
        count++;
    }
    public override void is_dead(){
        
    }
    public void Tick(){
        eat();
        reproduction();
        if(Energy_count>0){
            Energy_count-=1;
        }
        else{
            Point_of_life-=1;
        }
        if (Point_of_life==0){
            is_dead();
        }
    }
}