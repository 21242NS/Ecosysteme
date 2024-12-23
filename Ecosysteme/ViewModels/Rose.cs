using System;
using System.Collections.Generic;
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
        this.Range_of_food = 50;
        this.Maximum_point_of_life=100;
        this.Maximum_energy=35;
        this.Range_of_reproduction = 50;
    }
    
    public override Form_of_life reproduction(int time_of_reproduction)
    {   
        if(Count%time_of_reproduction==0){
            Console.WriteLine("here2");
            Random random = new Random();
            int locx = random.Next(-Range_of_reproduction,Range_of_reproduction+1);
            int locy = random.Next(-Range_of_reproduction,Range_of_reproduction+1);
            Point new_location = Location + new Point(locx,locy);
            Rose new_rose =new Rose(new_location);
            return new_rose;
        }
        return this;
    }
    
    public override ObservableCollection<GameObject> Tick(ObservableCollection<GameObject> objects, int Height, int Width){
        List<GameObject> inrange = is_in_Range(objects);
        List<GameObject> organics= is_food(inrange);
        GameObject food = find_near(organics);
        eat(food);
        Form_of_life new_plant= reproduction(500);
        if(Count%500==0){
            if(Energy_count>0){
            Energy_count-=1;
            }
            else{
            Point_of_life-=1;
            }
        }
        if (Point_of_life==0){
            Organic organic = turn_organic();
            objects.Add(organic);
            objects.Remove(this);
        }
        if(Dead){
            objects.Remove(this);
        }
        if(new_plant!=this){
            Console.WriteLine("here");
            objects.Add(new_plant);
        }
        Count++;
        return objects;
    }
   

}