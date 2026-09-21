using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to bake cake", "BakeryYT", 540);
        Comment comment1 = new Comment("Paul", "This looks delicious");
        Comment comment2 = new Comment("Jack", "I'll try, it looks very easy to do");
        Comment comment3 = new Comment("Henry", "Thanks for this tutorial!");

        video1.AddComment(comment1);
        video1.AddComment(comment2);
        video1.AddComment(comment3);

        videos.Add(video1);
        
        Video video2 = new Video("How to install a new SSD", "HardwareInfo", 360);
        Comment comment4 = new Comment("John", "Straight to the point, thanks!");
        Comment comment5 = new Comment("Mary", "Thank you so much, I didn't know where to start");
        Comment comment6 = new Comment("Travis", "Very useful");

        video2.AddComment(comment4);
        video2.AddComment(comment5);
        video2.AddComment(comment6);

        videos.Add(video2);

        Video video3 = new Video("This new game came out!", "JustPlaying", 540);
        Comment comment7 = new Comment("Ash", "It looks very fun!");
        Comment comment8 = new Comment("Owen", "I can't wait to play too");
        Comment comment9 = new Comment("Brigham", "LOL");

        video3.AddComment(comment7);
        video3.AddComment(comment8);
        video3.AddComment(comment9);

        videos.Add(video3);
    
        Console.WriteLine("--- YOUTUBE VIDEOS & COMMENTS DATA ---\n");

        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}