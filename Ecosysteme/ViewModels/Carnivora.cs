using System;
using Avalonia;
using Avalonia.Animation.Easings;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Pong.ViewModels;

public abstract partial class Carnivora : Animals  {
    public Carnivora(Point location) : base(location) {

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
                    if(a.Point_of_life<=0){
                        
                    }
                }
                else {
                    int demage = a.Defense-this.Attack_point;
                    this.Point_of_life-=demage;
                }
            }
        }
    
       
    }
    
}