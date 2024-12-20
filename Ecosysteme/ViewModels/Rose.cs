using System.Collections.ObjectModel;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Pong.ViewModels;

public partial class Rose : Plants {

    public Rose(Point location): base(location) {
        this.Point_of_life = 100;
        this.Energy_count= 35;
        this.Defense= 3;
        this.Range_of_food = 5;
        this.Maximum_point_of_life=100;
        this.Maximum_energy=35;
    }
    public override void eat(GameObject obj)
    {
        if (Energy_count < Maximum_energy){

        }
    }
    public override Form_of_life reproduction(int time_of_reproduction)
    {
        if(Count%time_of_reproduction==0){
            Point new_location = Location + new Point(1.0,0);
            Rose new_rose =new Rose(new_location);
            return new_rose;
        }
        Count++;
        return this;
    }
    public override void is_dead(){

    }
    public override ObservableCollection<GameObject> Tick(ObservableCollection<GameObject> objects, int Height, int Width){
        //eat();
        reproduction(1000);
        if(Energy_count>0){
            Energy_count-=1;
        }
        else{
            Point_of_life-=1;
        }
        if (Point_of_life==0){
            is_dead();
        }
        return objects;
    }
   

}