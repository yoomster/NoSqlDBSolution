namespace SwapiApiHomeworkUI.Models
{
    public class StarshipsModel
    {
            public string name { get; set; }
            public string model { get; set; }
            public string manufacturer { get; set; }
            public string cost_in_credits { get; set; }
            public string length { get; set; }
            public string max_atmosphering_speed { get; set; }
            public string crew { get; set; }
            public string passengers { get; set; }
            public string cargo_capacity { get; set; }
            public string consumables { get; set; }
            public string hyperdrive_rating { get; set; }
            public string MGLT { get; set; }
            public string starship_class { get; set; }
            public string[] Pilots { get; set; }
            public FilmsModel[] Films { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
    }
}
