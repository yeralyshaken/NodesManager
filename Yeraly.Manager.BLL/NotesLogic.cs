using Yeraly.Manager.DAL;
using Yeraly.Manager.Entities;

namespace Yeraly.Manager.BLL;

public class NotesLogic
{
    private NotesJsonDAO _notesJsonDAO;
    public NotesLogic()
    {
        // TODO: костыльное решение, переделать
        _notesJsonDAO = new NotesJsonDAO();
    }

    public void AddNote(Note note) => _notesJsonDAO.AddNote(note);

    public void RemoveNote(Guid id) => _notesJsonDAO.RemoveNote(id);

    public void RemoveNote(Note note) => RemoveNote(note.ID);

    public void EditNote(Guid id, string newTitle, string newText) 
        => _notesJsonDAO.EditNote(id, newTitle, newText);

    public async Task<List<string>> GetAllTitles() => await _notesJsonDAO.GetAllNoteTitles();
}
