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
public partial class Pig : Herbivore  {

    public Pig(Point location, String gender) : base(location) { 
        this.Point_of_life = 200;
        this.Energy_count= 45;
        this.Defense= 9;
        this.Vision_range = 100;
        this.Speed = 5;
        this.Attack_speed = 100;
        this.Attack_point = 10;
        this.Maximum_energy =45;
        this.Maximum_point_of_life =200;
        this.Hit_box = 15;
        this.Attack_range =25;
        this.Velocity =new Point(1, 1);
        this.Gender=gender;
    }
    

    public override Form_of_life reproduction(int time_of_reproduction)
    {   
        if(Pregnant){
            Console.WriteLine(Count_pregnant%time_of_reproduction);
            if(Count_pregnant%time_of_reproduction==0){
                Random random = new Random();
                int random_number = random.Next(0,2);
                Count_pregnant=1;
                Pregnant = false;
                return new Pig(Location+ new Point(50,50), Type_of_gender[random_number]);
            }
            Count_pregnant++;
            return this;
        }
        
        return this;
    }
    public override ObservableCollection<GameObject> Tick(ObservableCollection<GameObject>gameobjects, int Height, int Width){
        next_position(Width,Height);
        List<GameObject> in_range = is_in_Range(gameobjects);
        List<GameObject> food_possibility = sort<Sheep,Plants,Plants>(in_range);
        List<GameObject> partners = find_partner(in_range);
        if(food_possibility.Count > 0 || partners.Count > 0){
            GameObject objectiv = find_near(food_possibility);
            GameObject partner = find_near(partners);
            if(this.Energy_count<20&&food_possibility.Count > 0){
                double distance = Math.Sqrt(Math.Pow(objectiv.Location.X-this.Location.X, 2)+Math.Pow(objectiv.Location.Y-this.Location.Y, 2));
                this.Velocity =moveit(objectiv.Location);
                if (distance<Hit_box+Attack_range){
                    Console.WriteLine(Energy_count);
                    Console.WriteLine(Point_of_life);
                    eat(objectiv);
                    Console.WriteLine(Energy_count);
                    Console.WriteLine(Point_of_life);
                }
            }
            else if(Energy_count>=15&&partners.Count > 0){
                double distance2 = Math.Sqrt(Math.Pow(partner.Location.X-this.Location.X, 2)+Math.Pow(partner.Location.Y-this.Location.Y, 2));
                Pig pig = (Pig)partner;
                if(pig.Pregnant==false&&Pregnant==false){
                this.Velocity =moveit(partner.Location);
                    if (distance2<Hit_box+Attack_range){
                    
                        if(Gender=="Female"&&Pregnant==false){
                            set_pregnant();
                        }
                        else if(Gender=="Male"&&pig.Pregnant==false){
                            pig.set_pregnant();
                        }
                    }
                }
                else{
                    if(Count%100==0){
                        this.Velocity = random_move(Height-100, Width-100);
                    }
                }
                
            }
            }
        else if(Count%100==0){
            this.Velocity = random_move(Height-50, Width-50);
        }
        
        Count++;
        if (Point_of_life<=0){
            Meat meat = animal_died();
            gameobjects.Add(meat);
            gameobjects.Remove(this);
        }
        Form_of_life new_born = reproduction(200);

        if (new_born != this){
            gameobjects.Add(new_born);
        }
        if(Count%100==0){
            if(Energy_count>0){
                Energy_count-=1;
            }
            else{
                Point_of_life-=1;
            }
        }
        if(Count%1000==0){
            Organic organic = poop();
            gameobjects.Add(organic);
        }
        
 
        
        return gameobjects;
    }


 
}