namespace MeetsApi.Models
{
    public class Meet
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Plan { get; set; }
            public string Organizer { get; set; }

            public string Time { get; set; }
            public string Place { get; set; }

        }
}
