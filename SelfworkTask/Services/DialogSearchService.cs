using Ardalis.GuardClauses;
using SelfworkTask.Models;

namespace SelfworkTask.Services;

public class DialogSearchService : IDialogSearchService
{
    private readonly List<RGDialogsClients> _dialogsClients;

    public DialogSearchService()
    {
        _dialogsClients = new RGDialogsClients().Init();
    }

    public Guid SearchDialog(List<Guid> clients)
    {
        Guard.Against.Null(clients);

        if (clients.Count == 0)
            return Guid.Empty;

        var clientDialogLookup = _dialogsClients
            .ToLookup(list => list.IDClient, list => list.IDRGDialog);

        var result = clientDialogLookup[clients[0]];
        for (int i = 1; i < clients.Count; i++)
        {
            result = result.Intersect(clientDialogLookup[clients[i]]);
        }

        return result.FirstOrDefault();
    }
}
