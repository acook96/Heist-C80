List <TeamMember> teamMembers = new List<TeamMember>()
{
    new TeamMember() 
    {
    Name = "Jackie Lawson",
    SkillLevel = 40,
    CourageFactor = 3.0M
    },
    new TeamMember()
    {
    Name = "Sara McCallister",
    SkillLevel = 50,
    CourageFactor = 2.5M
    },
    new TeamMember()
    {
    Name = "Dr. Kenneth Noisewater",
    SkillLevel = 60,
    CourageFactor = 2.1M
    },
};

Console.WriteLine("Plan Your Heist!");
Console.WriteLine("First thing's first: How secure is the bank? (1-150)");
int bankDiff = int.Parse(Console.ReadLine());

while (bankDiff > 150)
{
    Console.WriteLine("Whoa there! Difficulty too high. Try 1-150.");
    bankDiff = int.Parse(Console.ReadLine());
}

int trials = 0;
 
string choice = null;
while (choice != "0")
{
    
    Console.WriteLine(@"
    Menu:
    0. Exit
    1. List all team members
    2. Add a team member
    3. Start the Heist
    ");
choice = Console.ReadLine().Trim();
if (choice == "0")
    {
        Console.WriteLine("Goodbye, you coward.");
    }
else if (choice == "1")
    {
        ViewMembers();
    }
else if (choice == "2")
    {
        AddMember();
    }
else if (choice == "3")
    {
        ExecuteHeist();
    }
}

void ViewMembers()
{
    foreach (TeamMember teammate in teamMembers)
    {
        Console.WriteLine($"{teammate.Name} - Skill level: {teammate.SkillLevel} - Courage: {teammate.CourageFactor}.");
    };   
};

void AddMember() 
{
    
    string memberName;
    while (true)
    {
        Console.WriteLine("Enter Your Team Member's Name:");
        memberName = Console.ReadLine().Trim();

        if (!string.IsNullOrEmpty(memberName))
        {
            break;
        }
        Console.WriteLine("Name cannot be empty. Please try again.");
    }
    Console.WriteLine($"Member name set to {memberName}.");

    Console.WriteLine("What is their skill level?:");
    int memberSkillLevel = int.Parse(Console.ReadLine().Trim());

    Console.WriteLine($"Skill level set to {memberSkillLevel}.");

    Console.WriteLine("What is their courage factor? (0.0-4.0)");
    
    decimal memberCourageFactor = 0;
    if (decimal.TryParse(Console.ReadLine(), out memberCourageFactor))
    {
        Console.WriteLine($"Courage factor set to {memberCourageFactor}.");
    }
    else
    {
        Console.WriteLine("Invalid number");
    }
    TeamMember member = new TeamMember()
    {
        Name = memberName,
        SkillLevel = memberSkillLevel,
        CourageFactor = memberCourageFactor
    };

    teamMembers.Add(member);

    Console.WriteLine(@$"New team member name: {member.Name}
    New skill level: {member.SkillLevel}
    New courage factor: {member.CourageFactor}");
};


void ExecuteHeist()
{
    List <string> chickens = new List<string>();

    int successes = 0;
    int failures = 0;

    Console.WriteLine("Time for a trial run! How many practice attempts do you want to make?");
    int trials = int.Parse(Console.ReadLine());
    for (int i = 1; i <= trials; i++)
    {
            
        int sumLvl = 0;

        foreach (TeamMember member in teamMembers)
        {
            if (member.ChickenFactor > bankDiff)
                {
                    sumLvl += member.SkillLevel;
                }
            else
                {
                    chickens.Add($"Trial {i}: {member.Name} chickened out! BAWK BAWK!!!");
                };
        }

        Random randomNumber = new Random();
        int luck = randomNumber.Next(-10, 10);  
        int newDiff = bankDiff + luck;
        
        Console.WriteLine($"Trial {i}");
        Console.WriteLine($"Bank difficulty level: {newDiff}");
        Console.WriteLine($"Team total skill level: {sumLvl}");
        if (luck <= 1)
            {
                Console.WriteLine("Your team is lucky! Fewer guards than usual!");
            }
            else if (luck == 0)
            {
                Console.WriteLine("Normal shift. Everything looks like what you're expecting...");
            }
            else
            {
                Console.WriteLine("You got unlucky. More guards than usual!");
            };

        if (sumLvl >= newDiff)
        {
            Console.WriteLine("Success: Your Team is skilled enough to pull this off.");
            successes++;
        }
        else
        {
            Console.WriteLine("Fail: You will go to jail.");
            failures++;
        }

        
    }
    foreach (string chicken in chickens)
        {
            Console.WriteLine(chicken);
        }
        
    Console.WriteLine($@"
    Final report:
    W: {successes} 
    L: {failures}");
    
};