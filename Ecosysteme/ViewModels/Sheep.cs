using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using Avalonia;
using Avalonia.Animation.Easings;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;


namespace Pong.ViewModels;
public partial class Sheep : Herbivore  {
    [ObservableProperty]
    private int count =0;
    public Sheep(Point location, String gender) : base(location) { 
        this.Point_of_life = 100;
        this.Energy_count= 35;
        this.Defense= 3;
        this.Vision_range = 250;
        this.Speed = 3;
        this.Attack_speed = 100;
        this.Attack_point = 10;
        this.Maximum_energy =35;
        this.Maximum_point_of_life =100;
        this.Hit_box = 15;
        this.Attack_range =25;
        this.Velocity =new Point(1, 1);
        this.Gender=gender;
    }
    

    
    public override ObservableCollection<GameObject> Tick(ObservableCollection<GameObject>gameobjects, int Height, int Width){
        List<GameObject> in_range = is_in_Range(gameobjects, this.Vision_range);
        List<GameObject> food_possibility = sort<Sheep,Plants,Plants>(in_range);
        if(food_possibility.Count > 0){
            GameObject objectiv = find_near(food_possibility);
            //double distance = Math.Sqrt(Math.Pow(objectiv.Location.X-this.Location.X, 2)+Math.Pow(objectiv.Location.Y-this.Location.Y, 2));
            this.Velocity = moveit(objectiv.Location);
            //if (distance<Hit_box+Attack_range){

            //}

            }
        else if(Count>100){
            this.Velocity = random_move(Height-50, Width-50);
            Count =0;
        }
        Location = Location + Velocity;
        Count++;

        
                    
                    
                
            
        
        return gameobjects;
    }

 
}