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
public partial class Lions : Carnivora  {
    [ObservableProperty]
    private int count =0;
    public Lions(Point location) : base(location) { 
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
    }
    

    
    public override ObservableCollection<GameObject> Tick(ObservableCollection<GameObject>gameobjects){
        List<GameObject> in_range = is_in_Range(gameobjects, this.Vision_range);
        List<GameObject> food_possibility = sort<Lions,Meat,Animals>(in_range);
        if(food_possibility.Count > 0){
            GameObject objectiv = find_near(food_possibility);
            double distance = Math.Sqrt(Math.Pow(objectiv.Location.X-this.Location.X, 2)+Math.Pow(objectiv.Location.Y-this.Location.Y, 2));
            this.Velocity = move(objectiv.Location);
            //if (distance<Hit_box+Attack_range){

            //}

            }
        else if(Count>100){
            Random random = new Random();
            int number1 = random.Next(-3, 4); 
            int number2 = random.Next(-3, 4);
            this.Velocity = new Point(number1, number2);
            Count =0;
        }
        Location = Location + Velocity;
        Count++;

        
                    
                    
                
            
        
        return gameobjects;
    }

 
}