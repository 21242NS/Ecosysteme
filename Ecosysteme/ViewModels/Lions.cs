using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using Avalonia;
using Avalonia.Animation.Easings;
using CommunityToolkit.Mvvm.ComponentModel;


namespace Pong.ViewModels;
public partial class Lions : Carnivora  {   
    public Lions(Point location) : base(location) { 
        this.Point_of_life = 100;
        this.Energy_count= 35;
        this.Defense= 3;
        this.Vision_range = 5;
        this.Speed = 3;
        this.Attack_speed = 100;
        this.Attack_point = 10;
        this.Maximum_energy =35;
        this.Maximum_point_of_life =100;
    }
    public Point move(Point loc){
        double multX = (loc.X-this.Location.X)/this.Speed;
        double multY = (loc.Y-this.Location.Y)/this.Speed;
        double velocity_X = (loc.X-this.Location.X)/multX;
        double velocity_Y = (loc.Y-this.Location.Y)/multY;
        Point velocity = new Point(velocity_X,velocity_Y);
        return velocity;
    }

    public override void eat(GameObject obj) {
        if (obj is Meat){
            if (this.Point_of_life==this.Maximum_point_of_life&& this.Energy_count< this.Maximum_energy){
                this.Energy_count += 5;
            }
            else {
                this.Point_of_life += 5;
                if (this.Point_of_life>this.Maximum_point_of_life){
                    this.Point_of_life = this.Maximum_point_of_life;
                }
            }
        }
        else {
            if(obj is Animals){
                Animals a = (Animals) obj;
                if(this.Attack_point>a.Defense){
                    int demage = this.Attack_point-a.Defense;
                    a.Point_of_life -= demage;
                }
                else {
                    int demage = a.Defense-this.Attack_point;
                    this.Point_of_life-=demage;
                }
            }
        }
       
    }
    

 
}