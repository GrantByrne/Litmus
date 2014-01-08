                                 __         __     ______   __    __     __  __     ______    
                                /\ \       /\ \   /\__  _\ /\ "-./  \   /\ \/\ \   /\  ___\   
                                \ \ \____  \ \ \  \/_/\ \/ \ \ \-./\ \  \ \ \_\ \  \ \___  \  
                                 \ \_____\  \ \_\    \ \_\  \ \_\ \ \_\  \ \_____\  \/\_____\ 
                                  \/_____/   \/_/     \/_/   \/_/  \/_/   \/_____/   \/_____/ 

Litmus
======

A .NET Api for Calculating the Average Color of the Screen

Introduction
------------

Litmus is an API which is used to quickly get the Average Color or the Most Prominent color displayed on the screen.

**Important Note**

Currently, Litmus doesn't have the ability to detect the average color of the screen while playing a full screen game. To add support for this, we would need a way to read color data directly from the GPU framebuffer, which I don't currently know how to do. But, it's on the backlog.


Getting Started
---------------

**Getting a Hold of It**

You can access the NuGet package [**Here**](https://www.nuget.org/packages/Litmus/).

**Getting the Average Color of the Screen**

    class Program
    {
        static void Main(string[] args)
        {
            ILitmus litmus = new DirectxColorProvider();
            
            // Get the Average Color of the Screen
            LitmusColor color = litmus.GetAverageColor();

            Console.WriteLine("Red:{0}\nGreen:{1}\nBlue:{2}\n", color.Red, color.Green, color.Blue);
            Console.ReadLine();
        }
    }

**Getting the Most Common Color on the Screen**

    class Program
    {
        static void Main(string[] args)
        {
            ILitmus litmus = new DirectxColorProvider();
            
            // Get the Average Color of the Screen
            LitmusColor color = litmus.GetMostCommonColor();

            Console.WriteLine("Red:{0}\nGreen:{1}\nBlue:{2}\n", color.Red, color.Green, color.Blue);
            Console.ReadLine();
        }
    }

Issues/Feature Requests
-----------------------

Please add an entry to the issues section of the Repository. I would like to continue developing this API in way that is useful to other people.
