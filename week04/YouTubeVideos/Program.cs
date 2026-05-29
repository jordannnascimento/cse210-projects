using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learn C# from Scratch", "CodeChannel", 720);
        video1.AddComment(new Comment("Ana", "Great video, helped me a lot!"));
        video1.AddComment(new Comment("Bruno", "Could you explain inheritance more?"));
        video1.AddComment(new Comment("Carla", "Saved my exam, thank you!"));
        videos.Add(video1);

        Video video2 = new Video("Homemade Bread Recipe", "Grandmas Kitchen", 480);
        video2.AddComment(new Comment("Daniel", "Turned out perfect at home."));
        video2.AddComment(new Comment("Eduarda", "What flour brand do you use?"));
        video2.AddComment(new Comment("Felipe", "My dough didnt rise, what went wrong?"));
        videos.Add(video2);

        Video video3 = new Video("20-Minute Home Workout", "Fit Total", 1200);
        video3.AddComment(new Comment("Gabriela", "I sweated a lot, excellent!"));
        video3.AddComment(new Comment("Henrique", "I do this every day now."));
        video3.AddComment(new Comment("Isabela", "Is there a no-jumping version?"));
        video3.AddComment(new Comment("Joao", "Loved the pace of the workout."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}