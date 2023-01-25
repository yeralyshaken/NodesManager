namespace Yeraly.Manager.Entities;

public class Note
{
    public Note(string title, string text)
    {
        ID = Guid.NewGuid();
        DateOfCreation = DateTime.Now;
        Title = title;
        Text = text;
    }

    public Guid ID { get; }
    public string Title { get; set; }
    public string Text { get; private set; }
    public DateTime DateOfCreation { get; }

    public void Edit(string newText)
    {
        if (string.IsNullOrEmpty(newText.Trim())) 
            throw new ArgumentNullException(nameof(newText), "Text can not be null");

        Text = newText;
    }
}
