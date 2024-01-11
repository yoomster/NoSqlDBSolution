﻿namespace SwapiApiHomeworkUI.Models
{
    public class SpeciesModel
    {
            public string Name { get; set; }
            public string Classification { get; set; }
            public string Designation { get; set; }
            public string Average_height { get; set; }
            public string Skin_colors { get; set; }
            public string Hair_colors { get; set; }
            public string Eye_colors { get; set; }
            public string Average_lifespan { get; set; }
            public string Homeworld { get; set; }
            public string Language { get; set; }
            public PeopleModel[] People { get; set; }
            public FilmsModel[] Films { get; set; }
            public DateTime Created { get; set; }
            public DateTime Edited { get; set; }
            public string Url { get; set; }
    }
}
