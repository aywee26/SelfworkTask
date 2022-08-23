using SelfworkTask.Services;

namespace SelfworkTask.Tests;

public class DialogSearchServiceTests
{
    private IDialogSearchService _service;
    private List<Guid> _clients;

    [SetUp]
    public void Setup()
    {
        _service = new DialogSearchService();
        _clients = new List<Guid>();
    }

    [Test]
    public void OnEmptyList_ReturnGuidEmpty()
    {
        var result = _service.SearchDialog(_clients);

        Assert.That(result, Is.EqualTo(Guid.Empty));
    }

    [Test]
    public void OnInvalidClient_ReturnGuidEmpty()
    {
        _clients.Add(new Guid("00000000-0000-0000-0000-000000000000"));

        var result = _service.SearchDialog(_clients);

        Assert.That(result, Is.EqualTo(Guid.Empty));
    }

    [Test]
    public void OnValidClient_ReturnGuidOfFirstDialog()
    {
        _clients.Add(new Guid("50454d55-a73c-4cbc-be25-3c5729dcb82b"));

        var result = _service.SearchDialog(_clients);

        Assert.That(result, Is.EqualTo(new Guid("83ebeb2b-c315-48a2-b6e5-f0324de57a9f")));
    }

    [Test]
    public void OnValidClients_ReturnGuidOfFirstDialog()
    {
        _clients.Add(new Guid("4b6a6b9a-2303-402a-9970-6e71f4a47151"));
        _clients.Add(new Guid("c72e5cb5-d6b4-4c0c-9992-d7ae1c53a820"));

        var result = _service.SearchDialog(_clients);

        Assert.That(result, Is.EqualTo(new Guid("fcd6b112-1834-4420-bee6-70c9776f6378")));
    }

    [Test]
    public void OnNotIntersectingClients_ReturnGuidEmpty()
    {
        _clients.Add(new Guid("4b6a6b9a-2303-402a-9970-6e71f4a47151"));
        _clients.Add(new Guid("0a58955e-342f-4095-88c6-1109d0f70583"));

        var result = _service.SearchDialog(_clients);

        Assert.That(result, Is.EqualTo(Guid.Empty));
    }
}