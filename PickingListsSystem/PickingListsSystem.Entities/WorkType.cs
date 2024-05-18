namespace PickingListsSystem.Entities
{
    public class WorkType
    {
        public int Id { get; set; }

        public int? TypeOfWork { get; set; } 

        public string? WorkTypeTranscript { get; set; }

        ////public ICollection<Work> Works { get; set; } = new List<Work>();

        //public ICollection<Project> Project { get; set; } = new List<Project>();

    }
}
