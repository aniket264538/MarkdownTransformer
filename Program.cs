using System;
using System.IO;
using Markdig;

class Program
{
    static void Main(string[] args)
    {
        // Check if a markdown file path is provided as an argument
        // if (args.Length == 0)
        // {
        //     Console.WriteLine("Please provide the path to the Markdown file as an argument.");
        //     return;
        // }

        string markdownFilePath = @"C:\Aniket Asus\Markdown_to_html\markdown-sample\charp-document.md";

        // Check if the file exists
        if (!File.Exists(markdownFilePath))
        {
            Console.WriteLine($"File not found: {markdownFilePath}");
            return;
        }

        // Read markdown content from file
        string markdownText = File.ReadAllText(markdownFilePath);

        // Convert Markdown to HTML
        string html = ConvertMarkdownToHtml(markdownText);

        // Store the HTML content in a file
        string htmlFilePath = Path.ChangeExtension(markdownFilePath, ".html");
        File.WriteAllText(htmlFilePath, html);

        Console.WriteLine($"HTML content has been saved to: {htmlFilePath}");
    }

    static string ConvertMarkdownToHtml(string markdownText)
    {
        // Configure the Markdown pipeline
        var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();

        // Convert Markdown to HTML
        string html = Markdig.Markdown.ToHtml(markdownText, pipeline);

        return html;
    }
}
