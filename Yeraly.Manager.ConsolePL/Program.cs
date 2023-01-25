global using System;
using System.Threading;
using Yeraly.Manager.BLL;
using Yeraly.Manager.Entities;


//var _logic = new NotesLogic();

//#region Get list of fileNames

//Console.WriteLine("All files:");
//var titles = await _logic.GetAllTitles();
//foreach (string titleName in titles)
//    Console.WriteLine(titleName);
//Console.WriteLine();
//#endregion

//#region Adding notes

//Console.WriteLine("Enter the title of note:");
//var title = Console.ReadLine();

//Console.WriteLine("Enter the text of note:");
//var text = Console.ReadLine();

//if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(title))
//{
//    _logic.AddNote(new Note(title, text));
//    Console.WriteLine("Successfully added new note!");
//}

//#endregion


#region Timer
Timer aTimer;
Timer bTimer;

SetTimer();

Console.WriteLine("\nPress the Enter key to exit the application...\n");
Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
Console.ReadLine();

aTimer.Dispose();
bTimer.Dispose();

Console.WriteLine("Terminating the application...");

void SetTimer()
{
    // Create a timer with a two second interval.
    aTimer = new Timer(OnTimedEvent, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

    bTimer = new Timer(OnTimedEventB, null, TimeSpan.Zero, TimeSpan.FromSeconds(0.2));
    int changeTo = new Random().Next(1, 10);
    Console.WriteLine(changeTo);
    bTimer.Change(TimeSpan.Zero, TimeSpan.FromSeconds(changeTo));

    changeTo = new Random().Next(1, 10);
    Console.WriteLine(changeTo);
    bTimer.Change(TimeSpan.Zero, TimeSpan.FromSeconds(changeTo));
}

void OnTimedEvent(Object source)
{
    Console.WriteLine($"The Elapsed event was raised at {DateTime.Now:HH:mm:ss.fff}");
}

void OnTimedEventB(Object source)
{
    Console.WriteLine("BTimer");
}

#endregion