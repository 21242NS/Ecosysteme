using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Pong.ViewModels;

public abstract partial class Animals : Form_of_life, Range {
    [ObservableProperty]
    private float vision_range;
    [ObservableProperty]
    private int attack_point;
    [ObservableProperty]
    private float attack_speed;
    [ObservableProperty]
    private float speed;
    [ObservableProperty]
    private float attack_range;
    [ObservableProperty]
    private Point velocity;
    [ObservableProperty]
    private String gender;
    [ObservableProperty]
    private List<String> type_of_gender=new List<String>{"Male", "Female"};
    [ObservableProperty]
    private Boolean pregnant = false;
    

    public Animals(Point location) : base(location) {

    }
    public bool type_of_food<T>(GameObject obj) where T : GameObject 
    {
        return (obj is T);
     }
    public List<GameObject> is_in_Range(ObservableCollection<GameObject> gameObjects) {
        List<GameObject> inrange = new List<GameObject>();
        foreach(GameObject obj in gameObjects)
        {
            double vector_range = Math.Sqrt(Math.Pow(obj.Location.X-this.Location.X, 2)+Math.Pow(obj.Location.Y-this.Location.Y, 2));
            if (vector_range<this.Vision_range){
                inrange.Add(obj);
            }
        }
        return inrange;
    }
    public GameObject find_near(List<GameObject> animal){
        GameObject game_object = null;
        foreach(GameObject obje in animal) {
            double vector_range = Math.Sqrt(Math.Pow(obje.Location.X-this.Location.X, 2)+Math.Pow(obje.Location.Y-this.Location.Y, 2));
            double near = this.Vision_range;
            if (vector_range<near){
                near = vector_range;
                game_object = obje;
            }
        }
        
        return game_object;
    }
    public List<GameObject> sort<T,S, H>(List<GameObject> obj) where T : GameObject
    where S : GameObject
    where H : GameObject
    {
        List<GameObject> animals=new List<GameObject>();
        foreach(GameObject objs in obj) {
            if(objs is S || type_of_food<H>(objs)){ 
                if(objs is not T){
                    animals.Add(objs);
                }
            }
        }
        return animals;
    }
    public List<GameObject> find_partner(List<GameObject> obj){
        List<GameObject> another_animal = new List<GameObject>();
        foreach( GameObject objs in obj) {
            if(objs.GetType() == this.GetType()){
                Animals a = (Animals)objs;
                if(a.Gender != this.Gender){
                    another_animal.Add(objs);
                }
            }
        }
        return another_animal;
    }
    public Point moveit(Point loc){
        if(loc.X-this.Location.X>0||loc.Y-this.Location.Y>0||loc.X-this.Location.X<0||loc.Y-this.Location.Y<0){
            double multX = (loc.X-this.Location.X)/this.Speed;
            double multY = (loc.Y-this.Location.Y)/this.Speed;
            if(multX==0){
                double velocity_y = (loc.Y-this.Location.Y)/Math.Abs(multY);
                Point velocity1 = new Point(0,velocity_y);
                return velocity1;
            }
            else if(multY==0){
                double velocity_x = (loc.X-this.Location.X)/Math.Abs(multX);
                Point velocity2 = new Point(velocity_x,0);
            return velocity2;
            }
            double velocity_X = (loc.X-this.Location.X)/Math.Abs(multX);
            double velocity_Y = (loc.Y-this.Location.Y)/Math.Abs(multY);
            Point velocity = new Point(velocity_X,velocity_Y);
            return velocity;
            }
        else {
            Point velocity = new Point(0,0);
            this.Location = loc;
            return velocity;
        }
    }
    public Point random_move(int Height, int Width){
        Random random = new Random();
        int number1 = random.Next(-3, 4); 
        int number2 = random.Next(-3, 4);
        if (number1 +Location.X<100||number1+Location.X>Width){
            Point move_random = new Point(-this.Velocity.X,this.Velocity.Y);
            return move_random;    
            }
        if(number2+Location.Y<100||number2+Location.Y>Height){
            Point move_random = new Point(this.Velocity.X,-this.Velocity.Y);
            return move_random;
        }
        else{
            Point move = new Point(number1, number2);
            return move;
        }
        
    }
    public Meat animal_died(){
        return new Meat(this.Location+new Point(10,10));
    }
    public void set_pregnant(){
        this.pregnant = true;
    }

    public Organic poop(){
        return new Organic(Location +new Point(10,10));
    }
    public void next_position(int Width, int Height){
        if(Location.X +Velocity.X<50 || Location.X+Velocity.X>Width-50){
                Velocity=new Point(-Velocity.X, Velocity.Y);
                Location = Location + Velocity;
            }
        else if(Location.Y+Velocity.Y<50||Location.Y+Velocity.Y>Height-50){
            Velocity=new Point(Velocity.X, -Velocity.Y);
            Location = Location + Velocity;
        }
        else{
            Location = Location + Velocity;
        }
    }
}