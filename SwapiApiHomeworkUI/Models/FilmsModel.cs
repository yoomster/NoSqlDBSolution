namespace SwapiApiHomeworkUI.Models
{
    public class FilmsModel
    {
            public string Title { get; set; }
            public int Episode_id { get; set; }
            public string Opening_crawl { get; set; }
            public string Director { get; set; }
            public string Producer { get; set; }
            public string Release_date { get; set; }
            public string[] Characters { get; set; }
            public PlanetsModel[] Planets { get; set; }
            public StarshipsModel[] Starships { get; set; }
            public VehiclesModel[] Vehicles { get; set; }
            public SpeciesModel[] Species { get; set; }
            public DateTime Created { get; set; }
            public DateTime Edited { get; set; }
            public string Url { get; set; }

    }
}
