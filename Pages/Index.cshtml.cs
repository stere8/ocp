using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    
    // Encapsulate DeveloperSkills as a property
    public Dictionary<string, List<string>> DeveloperSkills { get; private set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        // Initialize DeveloperSkills dictionary in OnGet method
        DeveloperSkills = new Dictionary<string, List<string>>
        {
            { "Development", new List<string>
                {
                    "C# (.NET)",
                    "ASP.NET",
                    "WPF",
                    "Entity Framework",
                    "SQL",
                    "Git",
                    "CI/CD practices",
                    "HTML",
                    "CSS",
                    "Vue.js"
                }
            },
            { "Process Improvement", new List<string>
                {
                    "Automation",
                    "Streamlining",
                    "Integration",
                    "Optimization",                    
                    "Agile/Scrum methodologies"
                }
            },
            { "Problem Solving", new List<string>
                {
                    "Debugging",
                    "Code review",
                    "Clean code writing",
                    "Project documentation"
                }
            },
            { "Customer Focus", new List<string>
                {
                    "Improved customer experiences through streamlined processes and enhanced applications"
                }
            },
            { "Adaptability", new List<string>
                {
                    "Quick learner",
                    "Open to new technologies"
                }
            },
            { "Soft Skills", new List<string>
                {
                    "Dedication",
                    "Hard work",
                    "Teamwork"
                }
            }
        };
    }
    
    public IActionResult OnPostSetLanguage(string culture, string returnUrl)
    {
        if (!string.IsNullOrEmpty(culture))
        {
            // Set the selected culture as the current UI culture
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
        }

        // Redirect back to the specified return URL
        return LocalRedirect(returnUrl);
    }
}
