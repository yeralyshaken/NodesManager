using Newtonsoft.Json;
using Yeraly.Manager.Entities;

namespace Yeraly.Manager.DAL;

public class NotesJsonDAO
{
    private readonly string JSON_FILES_PATH = $@"{Environment.CurrentDirectory}\Files\";
    public NotesJsonDAO()
    {
        if (!Directory.Exists(JSON_FILES_PATH)) Directory.CreateDirectory(JSON_FILES_PATH);
    }
    private string GetFilePath() => $"{JSON_FILES_PATH}data.json";
    private async Task<List<Note>> GetAllNotes()
    {
        List<Note>? notes;
        if (string.IsNullOrEmpty(await File.ReadAllTextAsync(GetFilePath())))
            notes = new List<Note>();
        else
            notes = JsonConvert.DeserializeObject<List<Note>>(await File.ReadAllTextAsync(GetFilePath()));

        if (notes is null) notes = new List<Note>();
        return notes;
    }

    public async void AddNote(Note note)
    {
        if (!File.Exists(GetFilePath())) File.Create(GetFilePath());

        var notes = await GetAllNotes();

        notes.Add(note);
        var json = JsonConvert.SerializeObject(notes);
        await File.AppendAllTextAsync(GetFilePath(), json);
    }

    public async void RemoveNote(Guid id)
    {
        if (!File.Exists(GetFilePath())) throw new FileNotFoundException();

        var notes = await GetAllNotes();

        if (notes.Any(x => x.ID == id))
            notes.Remove(notes.First(x => x.ID == id));
        else
            throw new FileNotFoundException(
                string.Format("Note {0} doesn't exist in {1}!", id, GetFilePath()));
    }

    public async void EditNote(Guid id, string newTitle, string newText)
    {
        if (!File.Exists(GetFilePath())) throw new FileNotFoundException();

        var notes = await GetAllNotes();

        if (notes.Any(x => x.ID == id))
        {
            var note = notes.First(x => x.ID == id);
            note.Title = newTitle;
            note.Edit(newText);
        }
        else
            throw new Exception(
                string.Format("Note {0} in data {1} doesn't exist!", id, GetFilePath()));

        var data = JsonConvert.SerializeObject(notes);
        await File.WriteAllTextAsync(GetFilePath(), data);
    }

    public async Task<List<string>> GetAllNoteTitles()
    {
        if (!File.Exists(GetFilePath())) return new List<string>();

        var notes = await GetAllNotes();

        return notes.Select(x => x.Title).ToList();
    }
}
