namespace FileBrowser;

public partial class FileBrowserForm : Form
{
    private FilePreviewer? _filePreviewer;

    public FileBrowserForm()
    {
        InitializeComponent();
    }

    private void openButton_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            _filePreviewer?.Dispose();
            _filePreviewer = new FilePreviewer(openFileDialog.FileName);
            var line = _filePreviewer.GetNextLine();
            resultTextBox.Text = line ?? "File is empty";
        }
    }

    private void nextButton_Click(object sender, EventArgs e)
    {
        if (_filePreviewer == null) return;
        var line = _filePreviewer.GetNextLine();
        resultTextBox.Text = line ?? "End of file";
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        _filePreviewer?.Dispose();
        _filePreviewer = null;
        resultTextBox.Text = "File closed";
    }
}

public class FilePreviewer : IDisposable
{
    private readonly StreamReader _reader;

    public FilePreviewer(string filePath)
    {
        _reader = new StreamReader(filePath);
    }

    public string? GetNextLine()
    {
        return _reader.ReadLine();
    }

    public void Dispose()
    {
        _reader.Dispose();
    }
}