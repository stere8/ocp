using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OCP.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public string YearsOfExperience;
    public Dictionary<string, List<string>> DeveloperSkills;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        YearsOfExperience = DateTime.Now.Subtract(new DateTime(2021, 09, 13)).Days % 365 == 0 ? "" : "over " + DateTime.Now.Subtract(new DateTime(2021, 09, 13)).Days / 365;
        
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
}