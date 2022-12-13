using Questao2;
using System.Net.Http.Json;
using static Questao2.Consts;

public class Program
{
    public static void Main()
    {
        MainAsync().Wait();
    }

    private static async Task MainAsync()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static async Task<int> getTotalScoredGoals(string team, int year)
    {
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(Urlbase);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(UrlFootballMatches + $"?year={year}&team1={team}");
            response.EnsureSuccessStatusCode();

            var data = new List<Data>();

            var footballMatches = await response.Content.ReadFromJsonAsync<FootballMatches>();

            await ProcessPages(data, footballMatches!, client, year, team, EnumsFiltersPage.Team1);

            var responseTeam2 = await client.GetAsync(UrlFootballMatches + $"?year={year}&team2={team}");
            responseTeam2.EnsureSuccessStatusCode();

            var footballMatchesTeam2 = await responseTeam2.Content.ReadFromJsonAsync<FootballMatches>();

            await ProcessPages(data, footballMatchesTeam2!, client, year, team, EnumsFiltersPage.Team2);

            var result = data.Where(x => x.Team1 == team).Select(y => y.Team1goals).Sum() + data.Where(x => x.Team2 == team).Select(y => y.Team2goals).Sum();

            return result;
        }
    }

    public static async Task ProcessPages(List<Data> data, FootballMatches footballMatches, HttpClient client, int year, string team, EnumsFiltersPage filtersPage)
    {
        _ = footballMatches ?? throw new ArgumentNullException(nameof(footballMatches));
        _ = footballMatches.Data ?? throw new ArgumentNullException(nameof(footballMatches.Data));
        _ = client ?? throw new ArgumentNullException(nameof(client));

        data.AddRange(footballMatches.Data);

        for (int i = 2; i <= footballMatches.Total_pages; i++)
        {
            var responseLoop = await client.GetAsync(UrlFootballMatches + $"?year={year}&{GetTextEnumFiltersPage(filtersPage)}={team}&page={i}");
            responseLoop.EnsureSuccessStatusCode();

            var footballMatchesLoop = await responseLoop.Content.ReadFromJsonAsync<FootballMatches>();

            if (footballMatchesLoop != null && footballMatchesLoop.Data != null)
            {
                data.AddRange(footballMatchesLoop.Data);
            }
        }
    }

    public static string GetTextEnumFiltersPage(EnumsFiltersPage filtersPage)
    {
        switch (filtersPage)
        {
            case EnumsFiltersPage.Team1: return "team1";
            case EnumsFiltersPage.Team2: return "team2";
            default: return "";
        }
    }
}